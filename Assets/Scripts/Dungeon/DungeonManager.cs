using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public List<Vector2> currentRoomsPositions = new List<Vector2>();
    public static DungeonManager instance { get; private set; }

    public static Vector2 roomMaxPositiveDistance = Vector2.zero;
    public static Vector2 roomMaxNegativeDistance = Vector2.zero;

    public GameObject[] roomPrefabs;
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
        
    }
}
