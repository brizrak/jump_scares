using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StartingPush : MonoBehaviour
{
    public static Rigidbody _rigidbody;
    public float push_force = 1200f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.sleepThreshold = 0.5f;
    }

    private void FixedUpdate()
    {
        if (StartGame.game_is_start && _rigidbody.velocity.magnitude > 0 && _rigidbody.velocity.magnitude < 3 && !(transform.position.y > 1))
        {
            _rigidbody.drag = 2f;
            if (_rigidbody.velocity.magnitude < 1)
            {
                _rigidbody.drag = 10f;
            }
        }
        else if (transform.position.y > 1)
        {
            _rigidbody.drag = 0.7f;
        }
    }

    public void Push(UnityEngine.Vector3 forward)
    {
        _rigidbody.drag = 0.7f;
        _rigidbody.AddForce(forward * push_force);
    }
}
