using System;
using StarterAssets;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // [SerializeField] Animator gunAnimator;
    [SerializeField] GameObject hitVFXPrefab;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int damageAmount = 1;
    StarterAssetsInputs starterAssetsInputs;

    const String SHOOT_STRING = "Shoot";
    // const String Gun_Show = "GunShowcase";

    void Awake()
    {
        starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
    }
    public void TakeDamage()
    {
        
    }
    // void Start()
    // {
    //     gunAnimator.Play(Gun_Show,0, 0f);
    // }
    void Update()
    {
        HandleShoot();
        
    }
    void HandleShoot()
    {
        if (starterAssetsInputs != null && starterAssetsInputs.shoot)
        {
            muzzleFlash.Play();
            animator.Play(SHOOT_STRING, 0, 0f);
            starterAssetsInputs.ShootInput(false);

            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Instantiate(hitVFXPrefab,hit.point,quaternion.identity);
                Enemy_Health enemyHealth = hit.collider.GetComponent<Enemy_Health>();
                if (enemyHealth)
                {
                    enemyHealth.TakeDamage(damageAmount);
                }
                
            }
        }
    }
}
