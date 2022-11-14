using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour {
    public Gun[] GunsPlayer;
    public int CurrentGunIndex;
    void Start() {
        TakeGunByIndex(CurrentGunIndex);
    }

    public void TakeGunByIndex(int gunIndex) {
        CurrentGunIndex = gunIndex;
        for (int i = 0; i < GunsPlayer.Length; i++) {
            if (i == gunIndex) {
                GunsPlayer[i].Activate();
            } else {
                GunsPlayer[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int numbersBullets) {
        GunsPlayer[gunIndex].AddBullets(numbersBullets);
    }
}
