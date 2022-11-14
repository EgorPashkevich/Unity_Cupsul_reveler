using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState {
    Disable,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public RopeRenderer RopeRenderer;

    public Transform Spawn;
    public float Speed;
    
    public float SpringJointSpring = 500f;
    public float SpringJointDamper = 20;

    public SpringJoint SpringJoint;

    public Transform RopeStart;

    private float _lenght;

    private RopeState _currentRopeState;

    public PlayerMove PlayerMove;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Shot();
        }
        if(_currentRopeState == RopeState.Fly) {
            
            float distance = Vector3.Distance(RopeStart.position, Hook.transform.position);
            if (distance > 20f) {
                Hook.gameObject.SetActive(false);
                _currentRopeState = RopeState.Disable;
                RopeRenderer.Hide();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (_currentRopeState == RopeState.Active) {
                if (PlayerMove.Grounded == false) {
                    PlayerMove.Jump();
                }
            }
            DestroySpring();
        }

        if (_currentRopeState == RopeState.Fly || _currentRopeState == RopeState.Active) {
            RopeRenderer.Draw(RopeStart.position, Hook.transform.position);
        }
    }

    public void Shot() {
        if (SpringJoint) {
            Destroy(SpringJoint);
        }

        Hook.gameObject.SetActive(true);

        Hook.StopFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.velocity = Spawn.forward * Speed;

        _currentRopeState = RopeState.Fly;

        
    }

    public void CreateSpring() {
        if (SpringJoint == null) {
            SpringJoint = gameObject.AddComponent<SpringJoint>();
            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.anchor = RopeStart.localPosition;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = SpringJointSpring;
            SpringJoint.damper = SpringJointDamper;

            _lenght = Vector3.Distance(RopeStart.position, Hook.transform.position);
            SpringJoint.maxDistance = _lenght;

            _currentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring() {
        if (SpringJoint) {
            Destroy(SpringJoint);
            _currentRopeState = RopeState.Disable;
            Hook.gameObject.SetActive(false);
            RopeRenderer.Hide();
        }
    }
}