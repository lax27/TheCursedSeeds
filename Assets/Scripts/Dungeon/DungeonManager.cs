using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public List<Vector2> CurrentRooms = new List<Vector2>();
    public List<GameObject> RoomsObjecs = new List<GameObject>();
    public List<GameObject> bossBugsRooms = new List<GameObject>();

    public static DungeonManager instance { get; private set; }

    public static Vector2 roomMaxPositiveDistance = Vector2.zero;
    public static Vector2 roomMaxNegativeDistance = Vector2.zero;

    public GameObject[] roomPrefabs;
    public GameObject[] bossRoomPrefabs;

    private int oneTime = 1;
    private bool bossRoomSpawned = false;

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
        CurrentRooms.Add(Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if (!bossRoomSpawned)
        {
            SpawnBossRoom();
        }


    }
    public void SpawnBossRoom()
    {
        GameObject LastSpawnedRoom = RoomsObjecs[RoomsObjecs.Count - 1];

        for (int i = 0; i < CurrentRooms.Count; i++)
        {
            Debug.Log(CurrentRooms[i]);
            Debug.Log(LastSpawnedRoom);
            for (int j = 0; j < LastSpawnedRoom.transform.childCount;j++)
            {
                Debug.Log(LastSpawnedRoom.transform.GetChild(j).gameObject.transform.position);
            }
  










            if (bossRoomSpawned) { break; }
        }
       
    }
}
