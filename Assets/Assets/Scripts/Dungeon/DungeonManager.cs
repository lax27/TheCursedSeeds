using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager instance { get; private set; }

    public List<Vector2> currentRoomsPositions = new List<Vector2>();
    public List<GameObject> RoomsObjecs = new List<GameObject>();
    public List<GameObject> bossRoomBugs = new List<GameObject>();

    public static Vector2 roomMaxPositiveDistance = Vector2.zero;
    public static Vector2 roomMaxNegativeDistance = Vector2.zero;

    public GameObject[] roomPrefabs;
    public GameObject[] nextFloorPrefab;

    [Header("Floor 1")]
    public List<GameObject> floors1Prefabs;

    [Header("Floor 2")]
    public List<GameObject> floors2Prefabs;

    [Header("Floor 3")]
    public List<GameObject> floors3Prefabs;

    [Header("Floor 4")]
    public List<GameObject> floors4Prefabs;

    [Header("Boss")]
    public List <GameObject> FinalBossPrefabs;


    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentRoomsPositions.Add(Vector2.zero);

        if (GameManager.instance.currentFloor == 1)
            roomPrefabs = floors1Prefabs.ToArray();

        if (GameManager.instance.currentFloor == 2)
            roomPrefabs = floors2Prefabs.ToArray();

        if (GameManager.instance.currentFloor == 3)
            roomPrefabs = floors3Prefabs.ToArray();

        if (GameManager.instance.currentFloor == 4)
            roomPrefabs = floors4Prefabs.ToArray();

        if(GameManager.instance.currentFloor == 5)
            roomPrefabs = FinalBossPrefabs.ToArray();
    }

    // Update is called once per frame
    void Update()
    {

        if (RoomsObjecs.Count < 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
    }
}
