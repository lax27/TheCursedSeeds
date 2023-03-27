using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ReturnToMainMenu()
    {
        //SceneManager.LoadScene("MainMenu");
        Debug.Log("Volviendo a MainMenu");
    }
}
