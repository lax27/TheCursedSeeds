using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public List<Vector2> currentRoomsPositions = new List<Vector2>();
    public List<GameObject> RoomsObjecs = new List<GameObject>();
    public List<GameObject> bossRoomBugs = new List<GameObject>();
    public static DungeonManager instance { get; private set; }

    public static Vector2 roomMaxPositiveDistance = Vector2.zero;
    public static Vector2 roomMaxNegativeDistance = Vector2.zero;

    public GameObject[] roomPrefabs;
    public GameObject[] bossRoomPrefabs;


    public int nextChild = 0;


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


    // Start is called before the first frame update
    void Start()
    {
        currentRoomsPositions.Add(Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
       
        
        GameObject room8 = GameObject.Find("Room 8");

        GameObject upChild = room8.transform.GetChild(0).gameObject;
        GameObject leftChild = room8.transform.GetChild(1).gameObject;
        GameObject rightChild = room8.transform.GetChild(2).gameObject;
        GameObject downChild = room8.transform.GetChild(3).gameObject;

        GameObject bossRoom = GameObject.Find("Boss0");
        GameObject bugRoom = GameObject.Find("Boss1");


        if (nextChild == 0)
        {
            GenerateBossRoom spawnBossRoom = leftChild.GetComponent<GenerateBossRoom>();
            if (spawnBossRoom != null)
                spawnBossRoom.enabled = true;
        }
        
        if (nextChild == 1)
        {
            GenerateBossRoom spawnBossRoom = upChild.GetComponent<GenerateBossRoom>();
            if (spawnBossRoom != null)
                spawnBossRoom.enabled = true;
        }
        
        if (nextChild == 2)
        {
            
            GenerateBossRoom spawnBossRoom = rightChild.GetComponent<GenerateBossRoom>();
            if(spawnBossRoom != null)
                spawnBossRoom.enabled = true;
        }

        if (nextChild == 3)
        {

            GenerateBossRoom spawnBossRoom = downChild.GetComponent<GenerateBossRoom>();
            if (spawnBossRoom != null)
                spawnBossRoom.enabled = true;
        }

        if (bugRoom != null)
        {
            Destroy(bugRoom);
            Debug.Log("Destoyed");
        }
        if (bossRoom == null)
        {
            StartCoroutine(CatchBugsRoom());

            if (bossRoom == null)
            {
                GenerateBossRoom spawnBossRoom = upChild.GetComponent<GenerateBossRoom>();
                if (spawnBossRoom != null)
                    spawnBossRoom.enabled = true;
            }
        }


    }

    IEnumerator CatchBugsRoom()
    {
        yield return new WaitForSecondsRealtime(5);
        Debug.Log("no ta el bozz");
    }
}
