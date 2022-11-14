using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEffect : MonoBehaviour {
    public GameObject EffectPrefab;
    public float Period;
    private float _timer;


    void Update() {
        _timer += Time.deltaTime;
        if (_timer > Period) {
            _timer = 0;
            Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
