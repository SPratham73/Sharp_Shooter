using UnityEngine;
using StarterAssets;

public class Player_Health : MonoBehaviour
{
    public int maxHealth = 10;
    int currentHealth;
    public Transform spawnPoint; 
    CharacterController controller;

    void Start()
     {
        currentHealth = maxHealth;
        controller = GetComponent<CharacterController>();

        if (spawnPoint == null)
        {
            spawnPoint = new GameObject("SpawnPoint").transform;
            spawnPoint.position = transform.position;
        }
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
        if (controller != null)
        {
            controller.enabled = false;
        }
        transform.position = spawnPoint.position;
        if (controller != null)
        {
            controller.enabled = true;
        }
    }
}
