using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public enum Wseeds {RABBIT,ICEHEART,LAST};

    public int[] inventory = new int[(int)Wseeds.LAST];

    public GameObject pauseMenu;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("WARNING: multiple" + this + "in scene!");
            Destroy(this);
        }
    }

    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

   
    void Update()
    {
        if (Input.GetButtonDown("Esc"))
        {
            if (pauseMenu != null)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

    }

    public void GrowingPlant(int seed_number)
    {

    }
}
