using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _playerTransform;
    public float Speed;
    public float TimeToMaxSpeed;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 forse = _rigidbody.mass * (toPlayer * Speed - _rigidbody.velocity) / TimeToMaxSpeed;

        _rigidbody.AddForce(forse);
    }
}
