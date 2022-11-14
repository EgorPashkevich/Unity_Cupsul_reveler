using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuButten;
    public GameObject MenuWindeow;

    public MonoBehaviour[] componentsToDisable;

    public void OpenMenuWindow()
    {
        MenuButten.SetActive(false);
        MenuWindeow.SetActive(true);

        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
        Time.timeScale = 0.01f;
    }

    public void CloseMenuWindow()
    {
        MenuButten.SetActive(true);
        MenuWindeow.SetActive(false);

        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = true;
        }
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
