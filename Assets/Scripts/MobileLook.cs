using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;

public class MobileLook : MonoBehaviour, IDragHandler
{
    public float sensitivity = 2f;

    StarterAssetsInputs inputs;

    void Start()
    {
        inputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;

        inputs.look = new Vector2(delta.x, delta.y) * sensitivity * 0.01f;
    }
}
