using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] PlayerMovement movement;
    [SerializeField] GameObject weapon;


    private void Start()
    {
        PauseMenu.SetActive(false);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
            movement.enabled = false;
            weapon.SetActive(false);
        }

    }

    public void PlayButton()
    {
        SceneManager.LoadScene("GameplayDefinitivoTest");
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

    public void PauseOff()
    {
        PauseMenu.SetActive(false);
        Debug.Log("clicked");
        movement.enabled = true;
        weapon.SetActive(true);
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
