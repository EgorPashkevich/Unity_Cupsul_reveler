using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject HealthIconPrefab;
    public List<GameObject> HealthIcons = new List<GameObject>();
    

    public void Setup(int MaxHeath){
        for (int i = 0; i < MaxHeath; i++)
        {
            GameObject newIcon = Instantiate(HealthIconPrefab, transform);
            HealthIcons.Add(newIcon);
        }
    }

    public void HealthDisplay(int Health){
        for (int i = 0; i < HealthIcons.Count; i++)
        {
            if (i < Health) {
                HealthIcons[i].SetActive(true);
            }else{
                HealthIcons[i].SetActive(false);
            }
        }
    }
}
