using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public enum Wseeds {RABBIT,ICEHEART,LAST};

    public int[] inventory = new int[(int)Wseeds.LAST];

    private float PlantTimer;
    public bool isPlanted = false;
    public bool isGrowed = false;
    public GameObject pile;
    public GameObject weapon;


    //--------------------------------------------------------------------------------
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
        if (isPlanted)
        {
            PlantTimer -= Time.deltaTime;
            if (PlantTimer <= 0)
            {
                isGrowed = true;
                PlantTimer = 0;
            }
        }

        if (isGrowed)
        {
            Instantiate(weapon, pile.transform.position,Quaternion.identity);
            isPlanted = false;
            isGrowed = false;
        }





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
        if (seed_number == 0 && !isPlanted )
        {
            isPlanted = true;
            PlantTimer = 300;
        }

        if (seed_number == 1 && !isPlanted )
        {
            isPlanted = true;
            PlantTimer = 420;
        }

    }
}
