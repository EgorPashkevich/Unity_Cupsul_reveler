
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour {
    public int Health;
    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnDie;


    public void TakeDamage(int damageValur) {
        Health -= damageValur;
        EventOnTakeDamage.Invoke();
        if (Health <= 0) Die();
    }

    public void Die() {
        Destroy(gameObject);
        EventOnDie.Invoke();
    }
}