using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoom : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject tp;

    private const int MAX_ROOMS = 8;

    // Start is called before the first frame update
    void Start()
    {
        bool roomCreatedInThisPosition = DungeonManager.instance.currentRoomsPositions.Contains(transform.position);

        int roomsAmount = DungeonManager.instance.currentRoomsPositions.Count;

        bool roomGenerationLimitExeeded = roomsAmount > MAX_ROOMS;


        bool canGenerate = !roomCreatedInThisPosition && !roomGenerationLimitExeeded;

        bool willGenerate = Random.Range(0f, 100f) > 50f || roomsAmount == 0;

        if (canGenerate && willGenerate) {
            int selectedPrefabIndex = Random.Range(0, DungeonManager.instance.roomPrefabs.Length);
            Instantiate(DungeonManager.instance.roomPrefabs[selectedPrefabIndex], transform.position, Quaternion.identity);
            DungeonManager.instance.currentRoomsPositions.Add(transform.position);
        }
        else
        {
            tp.SetActive(false);
        }
    }
}
