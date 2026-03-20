using UnityEngine;

public class EnemySpawn_Checkpoints : MonoBehaviour
{
    [SerializeField] Robot[] robots; 
    bool isActivated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            Debug.Log("Enemy spawned!!!!!");
            foreach (Robot r in robots)
            {
                if (r != null)
                {
                    r.ActivateRobot();
                }
                
            }
            GetComponent<Collider>().enabled = false;
            
        }
    }
}



