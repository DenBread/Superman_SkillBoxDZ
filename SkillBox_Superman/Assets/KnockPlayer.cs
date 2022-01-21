using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 10f, _layerMask))
        {
            var heading = hitInfo.transform.position - transform.position;
            if (hitInfo.rigidbody != null && heading.magnitude < 3f)
            {
                hitInfo.rigidbody.AddExplosionForce(500f, transform.position, 5f);
            }
            Debug.Log(heading.magnitude);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
        }
        else
        {
            Debug.Log("Hit nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.green);
        }
    }
}
