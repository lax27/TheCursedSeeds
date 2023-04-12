using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoom : MonoBehaviour
{
    public GameObject[] Rooms;
    public bool canGenerate;
    public bool Generate;
    public int roomCount = 0;
    public GameObject tp;

    

    // Start is called before the first frame update
    void Start()
    {
        canGenerate = !DungeonManager.instance.CurrentRooms.Contains(transform.position) && DungeonManager.instance.CurrentRooms.Count < 8;

        Generate = Random.Range(0f, 100f) > 50f ? true : false;
      

        if (canGenerate && Generate) {
            roomCount = Random.Range(0, GameManager.instance.roomPrefabs.Length);
            Instantiate(GameManager.instance.roomPrefabs[roomCount], transform.position, Quaternion.identity);
            DungeonManager.instance.CurrentRooms.Add(transform.position);
        }
        else
        {
            tp.SetActive(false);
        }
    }
}
