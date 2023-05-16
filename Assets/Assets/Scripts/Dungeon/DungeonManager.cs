using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager instance { get; private set; }

    public List<Vector2> currentRoomsPositions = new List<Vector2>();
    public List<GameObject> roomsObjecs = new List<GameObject>();
    public List<GameObject> bossRoomBugs = new List<GameObject>();

    public static Vector2 roomMaxPositiveDistance = Vector2.zero;
    public static Vector2 roomMaxNegativeDistance = Vector2.zero;

    public GameObject[] roomPrefabs;
    public GameObject[] nextFloorPrefab;

    [Header("Floor 1")]
    public List<GameObject> floor1Prefabs;

    [Header("Floor 2")]
    public List<GameObject> floor2Prefabs;

    [Header("Floor 3")]
    public List<GameObject> floor3Prefabs;

    [Header("Floor 4")]
    public List<GameObject> floor4Prefabs;

    [Header("Boss")]
    public List <GameObject> finalBossPrefabs;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentRoomsPositions.Add(Vector2.zero);

        if (GameManager.instance.currentFloor == 1)
            roomPrefabs = floor1Prefabs.ToArray();

        if (GameManager.instance.currentFloor == 2)
            roomPrefabs = floor2Prefabs.ToArray();

        if (GameManager.instance.currentFloor == 3)
            roomPrefabs = floor3Prefabs.ToArray();

        if (GameManager.instance.currentFloor == 4)
            roomPrefabs = floor4Prefabs.ToArray();

        if(GameManager.instance.currentFloor == 5)
            roomPrefabs = finalBossPrefabs.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (roomsObjecs.Count < 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
