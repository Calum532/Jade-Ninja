using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingController : MonoBehaviour
{
    public bool isAttacking;
    public ProjectileController projectile;
    public float projectileSpeed;
    public float timeBetweenAttacks;
    private float attackCounter;
    public Transform attackPoint;

    void Update()
    {
        if (isAttacking)
        {
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                attackCounter = timeBetweenAttacks;
                ProjectileController newProjectile = Instantiate(projectile, attackPoint.position, attackPoint.rotation) as ProjectileController;
                newProjectile.speed = projectileSpeed;
            }
        }
        else
        {
            attackCounter = 0;
        }
    }
}
