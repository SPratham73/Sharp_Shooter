using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Collect_Chip : MonoBehaviour
{
     public float interactDistance = 5f;
    public TextMeshProUGUI interactText;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        interactText.text = "";
    }

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Chip"))
            {
                interactText.text = "Press E to collect the chip";

               
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    CollectChip(hit.collider.gameObject);
                }

                return;
            }
        }

        // If not looking at chip
        interactText.text = "";
    }

    void CollectChip(GameObject chip)
    {
        Destroy(chip);

        interactText.text = "Chip collected! Run towards the exit!";

        Invoke(nameof(ClearText), 3f);
    }

    void ClearText()
    {
        interactText.text = "";
    }
}
