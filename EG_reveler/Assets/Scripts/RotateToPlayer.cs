using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public Vector3 LeftRotation;
    public Vector3 RightRotation;
    public float SpeedRotation;

    private Transform _playerTransfom;
    private Vector3 _targerRotation;
    void Start()
    {
        _playerTransfom = FindObjectOfType<PlayerMove>().transform;
    }

    
    void Update()
    {
        if (transform.position.x < _playerTransfom.position.x){
            // Rotate Right
            _targerRotation = RightRotation;
        } else {
            // Rotate Left
            _targerRotation = LeftRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targerRotation), SpeedRotation * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}
