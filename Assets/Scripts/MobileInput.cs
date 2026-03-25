using UnityEngine;
using StarterAssets;

public class MobileInput : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    

    StarterAssetsInputs inputs;

    void Start()
    {
        inputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    void Update()
    {
        // Movement
        inputs.move = new Vector2(moveJoystick.Horizontal, moveJoystick.Vertical);

      
        
    }
}