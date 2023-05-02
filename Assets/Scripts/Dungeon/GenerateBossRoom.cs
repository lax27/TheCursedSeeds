using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBossRoom : MonoBehaviour
{
    public bool canGenerate;
    public bool Generate;
    public int roomCount = 0;
    public GameObject tp;
  

    // Start is called before the first frame update
    void Start()
    {
        canGenerate = !DungeonManager.instance.currentRoomsPositions.Contains(transform.position) && DungeonManager.instance.currentRoomsPositions.Count < 1;
        if (canGenerate)
        {

            roomCount = Random.Range(0, DungeonManager.instance.bossRoomPrefabs.Length);
            Instantiate(DungeonManager.instance.bossRoomPrefabs[roomCount], transform.position, Quaternion.identity);
            DungeonManager.instance.currentRoomsPositions.Add(transform.position);
        }
        else
        {
            tp.SetActive(false);
        }
    }
}
