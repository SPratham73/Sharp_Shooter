using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int maxHealth = 10;
    int currentHealth;
    Vector3 spawnPoint;

    void Start()
    {
        currentHealth = maxHealth;
        spawnPoint = transform.position;
    }

    public void TakeDamage(int damage)
    {
        FindFirstObjectByType<DamageEffect>().ShowDamage();
        currentHealth -= damage;
        Debug.Log("Player Health: "+currentHealth);
        if(currentHealth <= 0)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        Debug.Log("Game Over!!!");
        currentHealth = maxHealth;
        transform.position = spawnPoint;
    }
}
