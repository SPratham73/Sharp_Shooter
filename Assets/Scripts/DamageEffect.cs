using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    public Image damageImage;
    public float fadeSpeed = 5f;

    float currentAlpha = 0f;

    void Update()
    {
        if (currentAlpha > 0)
        {
            currentAlpha -= fadeSpeed * Time.deltaTime;
            damageImage.color = new Color(1, 0, 0, currentAlpha);
        }
    }

    public void ShowDamage()
    {
        currentAlpha = 0.5f;
    }
}