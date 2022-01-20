using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bomb : MonoBehaviour
{
    public float radius, expForce;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            KnockBack();
        }
    }

    private void KnockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearyby in colliders)
        {
            Rigidbody rb = nearyby.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }
}
