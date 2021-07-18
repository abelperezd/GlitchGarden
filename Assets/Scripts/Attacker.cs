using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0.1f, 3f)]
    float currentSpeed = 1f;
    GameObject currentTarget;

    public void Awake() => FindObjectOfType<LevelController>().AttackerSpawned();
     public void OnDestroy() 
    {
        LevelController lc = FindObjectOfType<LevelController>();
        if (lc)
            lc.AttackerKilled();
    } 

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrickeCurrentTarget(float damage)
    {
        if (!currentTarget) return;
        Health health = currentTarget.GetComponent<Health>();

        if (health)
            health.DealDamage(damage);

    }

}
