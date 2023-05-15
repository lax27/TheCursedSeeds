using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBossRoom : MonoBehaviour
{
    public GameObject tp;
    private const int MAX_ROOMS = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BossSpawn());

    }

    IEnumerator BossSpawn()
    {
        yield return null;



        bool roomCreatedInThisPosition = DungeonManager.instance.currentRoomsPositions.Contains(transform.position);
        int roomsAmount = DungeonManager.instance.currentRoomsPositions.Count;
        bool roomGenerationLimitExceeded = roomsAmount > MAX_ROOMS + GenerateRoom.MAX_ROOMS;
        bool canGenerate = !roomCreatedInThisPosition && !roomGenerationLimitExceeded;

        if (canGenerate && gameObject.transform.parent.name.Contains("7"))
        {
            GameObject temp = Instantiate(DungeonManager.instance.nextFloorPrefab[0], transform.position, Quaternion.identity);
            temp.name = "Boss" + DungeonManager.instance.bossRoomBugs.Count;
            DungeonManager.instance.bossRoomBugs.Add(temp);
            DungeonManager.instance.currentRoomsPositions.Add(transform.position);
        }
        
        else
        {
            gameObject.SetActive(false);
            tp.SetActive(false);
        }

      
    }
}
