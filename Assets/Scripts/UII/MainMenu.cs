using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }

    public void BackButton()
    {
        settingsMenu.SetActive(false);
    }
}
