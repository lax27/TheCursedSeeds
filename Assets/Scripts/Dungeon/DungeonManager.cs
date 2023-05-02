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
        GameObject LastRoomSpawned = RoomsObjecs[RoomsObjecs.Count - 1];

        GameObject upChild = LastRoomSpawned.transform.GetChild(0).gameObject;
        GameObject leftChild = LastRoomSpawned.transform.GetChild(1).gameObject;
        GameObject rightChild = LastRoomSpawned.transform.GetChild(2).gameObject;
        GameObject downChild = LastRoomSpawned.transform.GetChild(3).gameObject;


        if (nextChild == 0)
        {
            GenerateBossRoom spawnBossRoom = upChild.GetComponent<GenerateBossRoom>();
            spawnBossRoom.enabled = true;
        }
        
        if (nextChild == 1)
        {
            GenerateBossRoom spawnBossRoom = leftChild.GetComponent<GenerateBossRoom>();
            spawnBossRoom.enabled = true;
        }
        
        if (nextChild == 2)
        {
            GenerateBossRoom spawnBossRoom = rightChild.GetComponent<GenerateBossRoom>();
            spawnBossRoom.enabled = true;
        }



    }
}
