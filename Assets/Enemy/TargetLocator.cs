using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
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
        Tank[] tanks = FindObjectsOfType<Tank>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Tank tank in tanks)
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
