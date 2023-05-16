using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        //1 = HUB_HUB
        SceneManager.LoadScene("1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
