using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public enum Wseeds {RABBIT,ICEHEART,LAST};
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    [Header("Inventory")]
    public int[] inventory = new int[(int)Wseeds.LAST];
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    [Header("Hub Things")]
    private float PlantTimer;
    public bool isPlanted = false;
    public bool isGrowed = false;
    public bool isWeapon = false;
    public GameObject pile;
    private GameObject spawnWeapon;
    public List<GameObject> weaponsToSpawn = new List<GameObject> ();
    public int currentWeaponID = 0;
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    [Header("Player Stadistics")]
    public bool TutorialPassed = false;
    public int runsDone = 0;
    public int totalEnemiesKilled = 0;
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
            Instantiate(spawnWeapon, pile.transform.position,Quaternion.identity);
            isPlanted = false;
            isGrowed = false;
            isWeapon = true;
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
            spawnWeapon = weaponsToSpawn[0];
            isPlanted = true;
            PlantTimer = 10;//300;
        }

        if (seed_number == 1 && !isPlanted )
        {
            spawnWeapon = weaponsToSpawn[1];
            isPlanted = true;
            PlantTimer = 420;
        }




    }
}
