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
    [SerializeField] GameObject menuPlant;


    private void Start()
    {
        PauseMenu.SetActive(false);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuPlant.active == true)
            {
                Debug.Log("Plant Menu on");
            }
            else if(menuPlant.active == false)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                movement.enabled = false;
                weapon.SetActive(false);

            }
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
        Time.timeScale = 1;

    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
