using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JupmGun : MonoBehaviour {
    public Rigidbody PlayerRigibody;
    public float Speed;
    public Transform Spawn;
    public Gun Pistol;

    public float MaxCharge = 3f;
    private float _currentCherge;
    private bool _isCharge;

    public ChargeIcon ChargeIcon;

    void Update() {

        if (_isCharge) {
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                PlayerRigibody.AddForce(-Spawn.forward * Speed, ForceMode.VelocityChange);
                Pistol.Shot();
                _isCharge = false;
                _currentCherge = 0;
                ChargeIcon.StartCharge();
            }
        } else {
            _currentCherge += Time.unscaledDeltaTime;
            ChargeIcon.SetChargeValue(_currentCherge, MaxCharge);
            if (_currentCherge >= MaxCharge) {
                _isCharge = true;
                ChargeIcon.StopCharge();
            }
        }

    }
}
