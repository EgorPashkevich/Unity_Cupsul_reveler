using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTriger : MonoBehaviour
{
    public int DamageValue;
    private void OnTriggerEnter(Collider collider) {
        if (collider.GetComponent<PlayerHealth>()){
            collider.GetComponent<PlayerHealth>().TakeDamage(DamageValue);
        }
    }
}
