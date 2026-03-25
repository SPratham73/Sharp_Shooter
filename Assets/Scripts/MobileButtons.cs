using UnityEngine;
using StarterAssets;

public class MobileButtons : MonoBehaviour
{
    StarterAssetsInputs inputs;

    void Start()
    {
        inputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    public void ShootDown()
    {
        inputs.ShootInput(true);
    }

    public void ShootUp()
    {
        inputs.ShootInput(false);
    }

    public void Jump()
    {
        inputs.JumpInput(true);
    }

    public void Interact()
    {
        inputs.InteractInput(true);
    }
}