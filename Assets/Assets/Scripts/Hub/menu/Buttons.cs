using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("HUB_HUB");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
