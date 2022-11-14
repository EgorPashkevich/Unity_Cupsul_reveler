using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    private Rigidbody _rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;

    public float MaxSpeed;

    public Transform TransformBodyCapsule;

    private int _jumpFrameCounter;


    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {

        if (Grounded == false) {
            TransformBodyCapsule.localScale = Vector3.Lerp(TransformBodyCapsule.localScale, new Vector3(1f, 0.5f, 1), Time.deltaTime * 15f);
        } else {
            TransformBodyCapsule.localScale = Vector3.Lerp(TransformBodyCapsule.localScale, new Vector3(1f, 1f, 1), Time.deltaTime * 15f);
        }

        if (Input.GetKeyDown(KeyCode.Space) & Grounded) {
            Jump();
        }
    }
    private void FixedUpdate() {

        float speedMultiplier = 1f;

        if (Grounded == false) {
            speedMultiplier = 0.2f;

            if (_rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0) speedMultiplier = 0;

            if (_rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0) speedMultiplier = 0;
        }

        _rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        if (Grounded) {
            _rigidbody.AddForce(-_rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }

        _jumpFrameCounter += 1;
        if (_jumpFrameCounter == 2) {
            _rigidbody.freezeRotation = false;
            _rigidbody.AddRelativeTorque(0, 0, 10f, ForceMode.VelocityChange);
        }
    }
    private void OnCollisionStay(Collision other) {
        float angle = Vector3.Angle(other.contacts[0].normal, Vector3.up);
        if (angle < 45f) {
            Grounded = true;
            _rigidbody.freezeRotation = true;
        }
    }
    private void OnCollisionExit(Collision other) {
        Grounded = false;
    }

    public void Jump() {
        _rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }
}
