using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour
{
    public Transform Target;
    public float SpeedRotate;

    void Update()
    {
        Vector3 toTarget = transform.position - Target.position;
        Quaternion CLAMP = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toTarget), SpeedRotate);
        transform.rotation = new Quaternion(Mathf.Clamp(CLAMP.x,-0.3f,0.3f), Mathf.Clamp(CLAMP.y,-0.3f,0.3f), 0f, CLAMP.w);
    }
}
