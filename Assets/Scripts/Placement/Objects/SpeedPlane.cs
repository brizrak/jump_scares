using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPlane : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float push_force = 1200f;
    public bool is_used = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!is_used)
        {
            is_used = true;
            _rigidbody = other.GetComponent<Rigidbody>();
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.AddForce(transform.forward * push_force);
        }
        
    }
}