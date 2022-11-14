using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMeneger : MonoBehaviour
{

    public AudioSource Music;
    public void SetMusicEnabled(bool value)
    {
        Music.enabled = value;
    }

    public void SetValue(float value)
    {
        AudioListener.volume = value;
    }
}
