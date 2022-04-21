using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocatorAlly : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15;
    Transform target;

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (targetDistance < range)
        {
            Attack(true);
        }
        else 
        {
            Attack(false);
        }
    }

    void FindClosestTarget()
    {
        EnemyMover[] tanks = FindObjectsOfType<EnemyMover>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(EnemyMover tank in tanks)
        {
            float targetDistance = Vector3.Distance(transform.position, tank.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = tank.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
