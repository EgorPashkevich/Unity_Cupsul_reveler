using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;

    private Transform _playerTransform;
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * Speed;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion rotationTarget = Quaternion.LookRotation(toPlayer, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationTarget, RotationSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}
