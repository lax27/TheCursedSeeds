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
    private float plantTimer;
    public bool isPlanted = false;
    public bool isGrown = false;
    public GameObject pile;
    private GameObject spawnWeapon;
    public List<GameObject> weaponsToSpawn = new List<GameObject> ();
    public int currentWeaponID = 0;

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Header("Player Game Stats")]
    public bool tutorialPassed = false;
    public int runsDone = 0;
    public int totalEnemiesKilled = 0;
    public int maxLives = 3;

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    //Dungeon things:
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

    void Update()
    {
        if(money >= 999999999)
        {
            money = 999999999;
        }

        if (money <= 0)
        {
            money = 0;
        }

        pile = GameObject.Find("PlantZone");

        if (isPlanted)
        {
            plantTimer -= Time.deltaTime;
            if (plantTimer <= 0)
            {
                isGrown = true;
                plantTimer = 0;
            }
        }

        if (isGrown)
        {
           GameObject weaponSpawnedTemp = Instantiate(spawnWeapon, pile.transform.position,Quaternion.identity);
            isPlanted = false;
            isGrown = false;
        }

        if (currentFloor == 2)
            floor1Passed = true;

        if (currentFloor == 3)
            floor2Passed = true;
        
        if (currentFloor == 4)
            floor3Passed = true;

        if (currentFloor == 5)
            bossPassed = true;

        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    public void GrowingPlant(int seed_number)
    {
        if (seed_number == 0 && !isPlanted )
        {
            spawnWeapon = weaponsToSpawn[0];
            isPlanted = true;
            plantTimer = 5f;
        }

        if (seed_number == 1 && !isPlanted )
        {
            spawnWeapon = weaponsToSpawn[1];
            isPlanted = true;
            plantTimer = 5f;
        }
    }

    public void SaveGame()
    {
        BinaryWriter writer = new BinaryWriter(File.Open("TheCursedSeeds.sav", FileMode.Create));

        writer.Write(inventory[0]);
        writer.Write(inventory[1]);
        //writer.Write(inventory[2]);       
        //writer.Write(inventory[3]);       
        //writer.Write(inventory[4]);       
        //writer.Write(inventory[5]);       
        //writer.Write(inventory[6]);       
        //writer.Write(inventory[7]);       
        //writer.Write(inventory[8]);

        //writer.Write(money);
        //writer.Write(PlantTimer);
        //writer.Write(isPlanted);
        //writer.Write(isGrowed);
        //writer.Write(TutorialPassed);
        //writer.Write(runsDone);
        //writer.Write(totalEnemiesKilled);
        //writer.Write(floor1Passed);
        //writer.Write(floor2Passed);
        //writer.Write(floor3Passed);
        //writer.Write(bossPassed);
        writer.Close();

    }

    public void LoadGame()
    {
        BinaryReader reader;
        if (File.Exists("TheCursedSeeds.sav")) {
            reader = new BinaryReader(File.Open("TheCursedSeeds.sav", FileMode.Open));

            inventory[0] = reader.ReadInt32();
            inventory[1] = reader.ReadInt32();
            //inventory[2] = reader.ReadInt32();
            //inventory[3] = reader.ReadInt32();
            //inventory[4] = reader.ReadInt32();
            //inventory[5] = reader.ReadInt32();
            //inventory[6] = reader.ReadInt32();
            //inventory[7] = reader.ReadInt32();
            //inventory[8] = reader.ReadInt32();

            //money = reader.ReadInt32();
            //PlantTimer = reader.ReadSingle();
            //isPlanted = reader.ReadBoolean();
            //isGrowed = reader.ReadBoolean();
            ////TutorialPassed = reader.ReadBoolean();
            //runsDone = reader.ReadInt32();
            //totalEnemiesKilled = reader.ReadInt32();
            //floor1Passed = reader.ReadBoolean();
            //floor2Passed = reader.ReadBoolean();
            //floor3Passed = reader.ReadBoolean();
            //bossPassed = reader.ReadBoolean();
        }
        else
        {
            return;
        }

        reader.Close();
    }
}
