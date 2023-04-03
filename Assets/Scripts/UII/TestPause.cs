using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TestPause : MonoBehaviour
{
    //FALTA CONFIGURAR QUE EL BACK TO MENU LLEVE AL MENU PRINCIPAL
    [SerializeField] GameObject pauseMenu;

    //esta variable es para evitar bugs visuales del menu de pause
    [SerializeField] private GameObject selectedButton;

    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        //hacer desaparecer el menu 
        pauseMenu.SetActive(false);
        //reanudar el tiempo
        Time.timeScale = 1.0f;
        //decir que el juego ya no está pausado
        isPaused = false;

        // Set the selected object to an empty object to remove focus from the button
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectedButton);
    }

    void PauseGame()
    {
        //hacer aparecer el menu 
        pauseMenu.SetActive(true);
        //parar el tiempo
        Time.timeScale = 0f;
        //decir que el juego está pausado
        isPaused= true;

        // Set the selected object to the resume button
        EventSystem.current.SetSelectedGameObject(selectedButton);
    }

    void GoToMainMenu()
    {
        //SceneManager.LoadScene("MainMenu");
    }
    
}
