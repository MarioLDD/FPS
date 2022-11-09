using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Rigidbody projectile;
    public float fireSpeed = 10;
    public void Lanzar()
    {
        Rigidbody fire = Instantiate(projectile, transform.position, transform.rotation);

        Vector3 worldDirection = transform.rotation * Vector3.forward;

        fire.velocity = worldDirection * fireSpeed;

    }
}


