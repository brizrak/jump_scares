using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPoint : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float push_force = 1200f;

    private void OnTriggerEnter(Collider other)
    {
        _rigidbody = other.GetComponent<Rigidbody>();
        Debug.Log(_rigidbody.velocity.normalized);
        _rigidbody.AddForce(_rigidbody.velocity.normalized * push_force);
    }
}
