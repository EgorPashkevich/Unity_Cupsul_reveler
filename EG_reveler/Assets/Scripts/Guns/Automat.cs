using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun {
    [Header("Automat")]
    public int NumbersBullets;
    public Text BulletsText;
    public PlayerArmory PlayerArmory;

    public override void Shot() {
        base.Shot();
        NumbersBullets -= 1;
        UpdateText();
        if (NumbersBullets == 0) {
            PlayerArmory.TakeGunByIndex(0);
        }
    }

    public override void Activate() {
        base.Activate();
        BulletsText.enabled = true;
        UpdateText();
    }

    public override void Deactivate() {
        base.Deactivate();
        BulletsText.enabled = false;
    }

    private void UpdateText() {
        BulletsText.text = "Пули: " + NumbersBullets.ToString();
    }

    public override void AddBullets(int numbersBullet) {
        base.AddBullets(numbersBullet);
        NumbersBullets += numbersBullet;
        UpdateText();
        PlayerArmory.TakeGunByIndex(1);
    }
}
