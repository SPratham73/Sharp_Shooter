using UnityEngine;

public class AirLock_Controller : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        anim.SetBool("isOpen", true);
    }

    public void CloseDoor()
    {
        anim.SetBool("isOpen", false);
    }
}
