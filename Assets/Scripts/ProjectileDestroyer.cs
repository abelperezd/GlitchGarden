using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D otherCollider)
    {
        Destroy(otherCollider.transform);
    }
}
