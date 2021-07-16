using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectile;
    void Start()
    {
        InvokeRepeating("Shoot", 1, 1.5f);
    }

    void Shoot()
    {
        Instantiate(projectile, -.35f * transform.right + transform.position, transform.rotation);
    }
}
