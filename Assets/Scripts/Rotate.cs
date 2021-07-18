using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] int speed = 1;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * -speed));
    }
}
