using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float BulletSpeed;
    public float ShotPeriod;
    private float _timer;
    public AudioSource ShotSound;
    public GameObject Flash;

    public ParticleSystem ShotEffectSmoke;


    void Update() {

        _timer += Time.deltaTime;
        if (_timer > ShotPeriod) {
            if (Input.GetMouseButton(0)) {
                _timer = 0;
                Shot();
            }
        }
    }

    public virtual void Shot() {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        ShotSound.Play();
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
        Flash.SetActive(true);
        Invoke("HideFlash", 0.2f);
        ShotEffectSmoke.Play();
    }

    public void HideFlash() {
        Flash.SetActive(false);
    }

    public virtual void Activate() {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate() {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numbersBullet) {
        // добавление пуль для автомата
    }
}
