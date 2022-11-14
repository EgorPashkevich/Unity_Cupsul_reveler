using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour {
    public int hHealthValue;
    private void OnTriggerEnter(Collider other) {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>()) {
            other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealth(hHealthValue);
            Destroy(gameObject);
        }
    }
}
