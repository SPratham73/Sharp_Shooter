using System;
using StarterAssets;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject hitVFXPrefab;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int damageAmount = 1;

    StarterAssetsInputs starterAssetsInputs;

    const String SHOOT_STRING = "Shoot";

    void Awake()
    {
        starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
      
        bool mobileShoot = (starterAssetsInputs != null && starterAssetsInputs.shoot);

        bool pcShoot = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

        if (mobileShoot || pcShoot)
        {
            muzzleFlash.Play();
            animator.Play(SHOOT_STRING, 0, 0f);

            // reset mobile input
            if (starterAssetsInputs != null)
            {
                starterAssetsInputs.ShootInput(false);
            }

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Instantiate(hitVFXPrefab, hit.point, quaternion.identity);

                Enemy_Health enemyHealth = hit.collider.GetComponent<Enemy_Health>();
                if (enemyHealth)
                {
                    enemyHealth.TakeDamage(damageAmount);
                }
            }
        }
    }
}