using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acom : MonoBehaviour
{
    public Vector3 Velocity;
    public float MaXRotationSpeed;
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
            Random.Range(-MaXRotationSpeed , MaXRotationSpeed),
            Random.Range(-MaXRotationSpeed , MaXRotationSpeed),
            Random.Range(-MaXRotationSpeed , MaXRotationSpeed)
        );
    }
}
