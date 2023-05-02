using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBossRoom : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        bool roomCreatedInThisPosition = DungeonManager.instance.currentRoomsPositions.Contains(transform.position);
        int roomsAmount = DungeonManager.instance.currentRoomsPositions.Count;
        bool canGenerate = !roomCreatedInThisPosition;


        if (canGenerate)
        {
            GameObject temp = Instantiate(DungeonManager.instance.bossRoomPrefabs[0], transform.position, Quaternion.identity);
            DungeonManager.instance.bossRoomBugs.Add(temp);
            Destroy(this);
        }
        
        if(DungeonManager.instance.nextChild == 0 && !canGenerate)
        {
            DungeonManager.instance.nextChild = 1;
        }
        
        if (DungeonManager.instance.nextChild == 1 && !canGenerate)
        {
            DungeonManager.instance.nextChild = 2;
        }
        
    }
}
