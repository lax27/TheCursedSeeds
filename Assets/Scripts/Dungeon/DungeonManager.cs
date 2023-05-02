using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public List<Vector2> CurrentRooms = new List<Vector2>();
    public List<GameObject> RoomsObjecs = new List<GameObject>();
    public static DungeonManager instance { get; private set; }

    public static Vector2 roomMaxPositiveDistance = Vector2.zero;
    public static Vector2 roomMaxNegativeDistance = Vector2.zero;

    public GameObject[] roomPrefabs;
    public GameObject[] bossRoomPrefabs;

    private int oneTime = 1;

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
        if(oneTime > 0)
        {
            for (int i = 0; i < CurrentRooms.Count; i++)
            {
                if (RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(0).transform.position.x != CurrentRooms[i].x && RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(0).transform.position.y != CurrentRooms[i].y)
                {
                    Instantiate(bossRoomPrefabs[0], RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(0).transform.position, Quaternion.identity);
                    break;
                }
                else if (RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(1).transform.position.x != CurrentRooms[i].x && RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(1).transform.position.y != CurrentRooms[i].y)
                {
                    Instantiate(bossRoomPrefabs[0], RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(1).transform.position, Quaternion.identity);
                    break;
                }
                else if (RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(2).transform.position.x != CurrentRooms[i].x && RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(2).transform.position.y != CurrentRooms[i].y)
                {
                    Instantiate(bossRoomPrefabs[0], RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(2).transform.position, Quaternion.identity);
                    break;
                }
                else if (RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(3).transform.position.x != CurrentRooms[i].x && RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(3).transform.position.y != CurrentRooms[i].y)
                {
                    Instantiate(bossRoomPrefabs[0], RoomsObjecs[RoomsObjecs.Count - 1].transform.GetChild(3).transform.position, Quaternion.identity);
                    break;
                }
            }
        }
        oneTime--;
    }
}
