using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        //SceneManager.LoadScene("BuenTuto");
        Debug.Log("Falta poner escena en el Build");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego ");
    }
}
