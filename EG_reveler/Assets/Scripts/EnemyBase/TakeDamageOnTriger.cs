using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTriger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollsion;

    private void OnTriggerEnter(Collider collider) {
        if (collider.GetComponent<Bullet>()){
            EnemyHealth.TakeDamage(1);
        }
        if(DieOnAnyCollsion){
            if(collider.isTrigger == false){
                EnemyHealth.Die();
            }
        }
    }
}
