using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;
    MeshRenderer[] meshes;

    public float attackDistance = 5f;
    public float attackRate = 0.5f;
    float nextAttackTime;
    Player_Health playerHealth;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        meshes = GetComponentsInChildren<MeshRenderer>();

        agent.enabled = false;
        foreach (MeshRenderer m in meshes)
        {
            m.enabled = false;
        }
    }
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        playerHealth = player.GetComponent<Player_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent!=null && agent.enabled && player != null)
        {

            agent.SetDestination(player.transform.position);
            float distance = Vector3.Distance(transform.position,player.transform.position);
            if(distance <= attackDistance)
            {
                agent.isStopped = true;
                AttackPlayer();
            }
            else
            {
                agent.isStopped = false;
            }
        }
    }
    void AttackPlayer()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackRate;

            Debug.Log("Enemy Attacked!");

            playerHealth.TakeDamage(1);
        }
    }

    public void ActivateRobot()
    {
        agent.enabled = true;

        foreach (MeshRenderer m in meshes)
        {
            m.enabled = true;
        }
    }
}
