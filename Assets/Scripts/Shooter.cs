using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;

    AttackerSpawner myLaneSpawner;

    Animator animator;

    const string PROJECTILE_PARENT_NAME = "Projectiles";

    GameObject projectiles;

    private void Start()
    {
        projectiles = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectiles)
            projectiles = new GameObject(PROJECTILE_PARENT_NAME);
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            if (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon)
            {
                myLaneSpawner = spawner;
                return;
            }
        }

        Debug.LogWarning("No attacker spawner found");
    }

    private void Update()
    {
        if (isAttackerInLine())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool isAttackerInLine()
    {
        return myLaneSpawner.transform.childCount > 0 ? true : false;
    }

    public void Fire(float damage)
    {
        Instantiate(projectile, gun.transform.position, transform.rotation, projectiles.transform);
    }
}
