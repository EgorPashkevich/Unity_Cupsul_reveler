using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollsion;
    private void OnCollisionEnter(Collision collision) {
        if(collision.rigidbody){
            if(collision.rigidbody.GetComponent<Bullet>()) 
                EnemyHealth.TakeDamage(1);
        }
        if(DieOnAnyCollsion){
            EnemyHealth.Die();
        }
    }
}
