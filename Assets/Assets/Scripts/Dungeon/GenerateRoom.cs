using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateRoom : MonoBehaviour
{
    public int roomCount = 0;
    public GameObject tp;
    public GameObject[] rooms;

    public const int MAX_ROOMS = 8;
    

    // Start is called before the first frame update
    void Start()
    {
        bool roomCreatedInThisPosition = DungeonManager.instance.currentRoomsPositions.Contains(transform.position);
        int roomsAmount = DungeonManager.instance.currentRoomsPositions.Count;
        bool roomGenerationLimitExceeded = roomsAmount > MAX_ROOMS;
        bool canGenerate = !roomCreatedInThisPosition && !roomGenerationLimitExceeded;
        bool willGenerate = Random.Range(0f, 100f) > 50f || roomsAmount == 0;


        if (canGenerate && willGenerate)
        {
            int selectedPrefabIndex = Random.Range(0, DungeonManager.instance.roomPrefabs.Length);
            GameObject temp = Instantiate(DungeonManager.instance.roomPrefabs[selectedPrefabIndex], transform.position, Quaternion.identity);
            temp.name = "Room " + DungeonManager.instance.RoomsObjecs.Count;
            DungeonManager.instance.RoomsObjecs.Add(temp);
            DungeonManager.instance.currentRoomsPositions.Add(transform.position);
            
            if(DungeonManager.instance.currentRoomsPositions.Count <= GenerateRoom.MAX_ROOMS)
            {
                gameObject.SetActive(false);
            }
        }
        else
        { 
            enabled = false;
        }
        
    }



}
