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
        canGenerate = !DungeonManager.instance.CurrentRooms.Contains(transform.position) && DungeonManager.instance.CurrentRooms.Count < 1;
        if (canGenerate)
        {

            roomCount = Random.Range(0, DungeonManager.instance.bossRoomPrefabs.Length);
            Instantiate(DungeonManager.instance.bossRoomPrefabs[roomCount], transform.position, Quaternion.identity);
            DungeonManager.instance.CurrentRooms.Add(transform.position);
        }
        else
        {
            tp.SetActive(false);
        }
    }
}
