using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public enum Wseeds { ICEHEART,RABBIT, LAST};
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    [Header("Inventory")]
    public int[] inventory = new int[(int)Wseeds.LAST];
    public int money = 0;
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    [Header("Hub Things")]
    private float PlantTimer;
    public bool isPlanted = false;
    public bool isGrowed = false;
    public GameObject pile;
    private GameObject spawnWeapon;
    public List<GameObject> weaponsToSpawn = new List<GameObject> ();
    public int currentWeaponID = 0;

    
    [Header("Player Stadistics")]
    public bool TutorialPassed = false;
    public int runsDone = 0;
    public int totalEnemiesKilled = 0;

    //Dungeon things:
    private GameObject guns;
   [SerializeField]public int currentFloor = 0;
    
    public bool floor1Passed = false;
    public bool floor2Passed = false;
    public bool floor3Passed = false;
    public bool bossPassed = false;

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

    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
           LoadGame();
        }

        if (money >= 999999999)
        {
            money = 999999999;
        }

        if (money <= 0)
        {
            money = 0;
        }

        guns = GameObject.Find("RotatePoint");
        pile = GameObject.Find("PlantZone");

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
           GameObject weaponSpawnedTemp = Instantiate(spawnWeapon, pile.transform.position,Quaternion.identity);
            isPlanted = false;
            isGrowed = false;
        }


        if (currentFloor == 2)
            floor1Passed = true;

        if (currentFloor == 3)
            floor2Passed = true;
        
        if (currentFloor == 4)
            floor3Passed = true;

        if (currentFloor == 5)
            bossPassed = true;

    }

    public void GrowingPlant(int seed_number)
    {
        if (seed_number == 0 && !isPlanted )
        {
            spawnWeapon = weaponsToSpawn[0];
            isPlanted = true;
            PlantTimer = 5f;
        }

        if (seed_number == 1 && !isPlanted )
        {
            spawnWeapon = weaponsToSpawn[1];
            isPlanted = true;
            PlantTimer = 5f;
        }
    }


    public void SaveGame()
    {
        BinaryWriter writer = new BinaryWriter(File.Open("TheCursedSeedGame.sav", FileMode.Create));


        //Write Ints
        writer.Write(inventory.Length);
        for (int i = 0; i < inventory.Length; i++)
        {
            writer.Write(inventory[i]);
        }
        //Write Floats
        
        //Write Bools

        writer.Close();
    }


    public void LoadGame()
    {
        BinaryReader reader;

        if (File.Exists("TheCursedSeedGame.sav"))
        {
            reader = new BinaryReader(File.Open("TheCursedSeedGame.sav", FileMode.Open));
        }
        else
        {
            return;
        }

        //Read Ints
        int length = reader.ReadInt32();

        for(int i = 0; i < length; i++)
        {
            inventory[i] = reader.ReadInt32();
        }
        //Read Floats

        //Read Bools

        reader.Close();
    }
}
