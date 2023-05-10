using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BugRooms : MonoBehaviour
{
    GameObject roomBug;
    GameObject roomBug2;
    // Start is called before the first frame update
    void Start()
    {
        //roomBug = GameObject.Find("Room 0");
        //roomBug2 = GameObject.Find("Room 1");
        if (DungeonManager.instance.currentRoomsPositions.Count < 4 && DungeonManager.instance.RoomsObjecs.Count < 3)
        {
            DungeonManager.instance.currentRoomsPositions.Clear();
            DungeonManager.instance.currentRoomsPositions.Add(Vector2.zero);
            DungeonManager.instance.RoomsObjecs.Clear();
            DungeonManager.instance.bossRoomBugs.Clear();
            Destroy(this);
        }


        //if (roomBug == null)
        //{
        //    DungeonManager.instance.currentRoomsPositions.Clear();
        //    DungeonManager.instance.currentRoomsPositions.Add(Vector2.zero);
        //    DungeonManager.instance.RoomsObjecs.Clear();
        //    DungeonManager.instance.bossRoomBugs.Clear();
        //    SceneManager.LoadScene(2);
        //    Destroy(this);
        //}

        //if (roomBug2 == null)
        //{
        //    DungeonManager.instance.currentRoomsPositions.Clear();
        //    DungeonManager.instance.currentRoomsPositions.Add(Vector2.zero);
        //    DungeonManager.instance.RoomsObjecs.Clear();
        //    DungeonManager.instance.bossRoomBugs.Clear();
        //    SceneManager.LoadScene(2);
        //    Destroy(this);
        //}
    }

    // Update is called once per frame
    void Update()
    {
    }
}
