using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float Speed;
    void Start()
    {
        transform.rotation = Quaternion.identity;
        _rigidbody = GetComponent<Rigidbody>();
        Transform playerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        _rigidbody.velocity = toPlayer * Speed;
    }

   
}
