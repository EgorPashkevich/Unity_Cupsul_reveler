using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Renderer[] Renderers;


    public void StartBlink(){
        StartCoroutine(BlinkEffect());
    }
    

    public IEnumerator BlinkEffect(){
        for (float t = 0; t < 1f; t+= Time.deltaTime)
        {
            for (int i = 0; i < Renderers.Length; i++)
            {
                for (int j = 0; j < Renderers[i].materials.Length; j++)
                {
                    Renderers[i].materials[j].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30f) * 0.5f + 0.5f, 0, 0, 0));
                }
            }
            yield return null;
        }
    }
}
