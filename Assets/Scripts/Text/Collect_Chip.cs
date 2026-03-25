using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.InputSystem;

public class Collect_Chip : MonoBehaviour
{
    public float interactDistance = 5f;
    public TextMeshProUGUI interactText;

    Camera cam;
    StarterAssetsInputs inputs;

    void Start()
    {
        cam = Camera.main;
        inputs = FindFirstObjectByType<StarterAssetsInputs>();
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
                
                interactText.text = "Press E / Tap to collect the chip";

                bool mobileInput = (inputs != null && inputs.interact);
                bool pcInput = Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame;

                if (mobileInput || pcInput)
                {
                    CollectChip(hit.collider.gameObject);

                    // reset mobile input
                    if (inputs != null)
                        inputs.interact = false;
                }

                return;
            }
        }

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