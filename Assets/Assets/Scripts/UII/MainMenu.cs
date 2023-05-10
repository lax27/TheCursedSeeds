using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;

    void Start()
    {

    }
    void Update()
    {
        
    }

    public void LoadSceneOnPlayButtonClick()
    {
        SceneManager.LoadScene("1");
    }

    public void OpenSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
    public void CloseGameOnExitButtonClick()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }

    public void BackButton()
    {
        settingsMenu.SetActive(false);
    }
    //PONER ESTO EN GAMEPLAY
    /*public void PauseOff()
    {
        PauseMenu.SetActive(false);
        Debug.Log("Pause is off");
        Time.timeScale = 1;

    }
    */

    //PONER ESTO EN EL MENU DE PAUSE
    /*
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    */
}
