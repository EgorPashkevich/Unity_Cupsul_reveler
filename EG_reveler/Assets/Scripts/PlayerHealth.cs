using UnityEngine;
using UnityEngine.Events;
public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public int MaxHealth;

    private bool _invulnerable = false;
    // public AudioSource TakeDamageSound;
    public AudioSource AddHealthSound;
    public HealthUI healthUI;
    // public DamageScreen DamageScreen;
    // public Blink Blink;

    public UnityEvent EventOnTakeDamage;

    private void Start() {
        healthUI.Setup(MaxHealth);
        healthUI.HealthDisplay(Health);
    }

    public void TakeDamage(int damageValue){

        if(_invulnerable == false){
            Health -= damageValue;
            if(Health <= 0){
                Health = 0;
                Die();
            }
            _invulnerable = true;
            // TakeDamageSound.Play();
            Invoke("StopInvulnerable", 1f);
            healthUI.HealthDisplay(Health);
            // DamageScreen.StartEffcet();
            // Blink.StartBlink();

            EventOnTakeDamage.Invoke();
        }

        
    }

    public void StopInvulnerable(){
        _invulnerable = false;
    }

    public void AddHealth(int healthValue){
        Health += healthValue;
        
        if (Health > MaxHealth) Health = MaxHealth;
        AddHealthSound.Play();
        healthUI.HealthDisplay(Health);
    }

    public void Die(){
        Debug.Log("You LOSE");
    }
}
