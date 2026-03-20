using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;
    int currenthealth;

    void Awake()
    {
        currenthealth = startingHealth;
    }
    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        if(currenthealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
