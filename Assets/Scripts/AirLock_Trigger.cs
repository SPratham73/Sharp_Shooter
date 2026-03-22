using UnityEngine;

public class AirLock_Trigger : MonoBehaviour
{
    public AirLock_Controller door;
    public bool openTrigger; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
                door.OpenDoor();
            else
                door.CloseDoor();
        }
    }
}

