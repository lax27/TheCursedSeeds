using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateRoom : MonoBehaviour
{
   
    public bool canGenerate;
    public bool Generate;
    public int roomCount = 0;
    public GameObject tp;
    private int currentRoomsNum;
    

    // Start is called before the first frame update
    void Start()
    {
        canGenerate = !DungeonManager.instance.CurrentRooms.Contains(transform.position) && DungeonManager.instance.CurrentRooms.Count < 8;

        Generate = Random.Range(0f, 100f) > 50f ? true : false;


        if (canGenerate && Generate)
        {

            roomCount = Random.Range(0, DungeonManager.instance.roomPrefabs.Length);
            GameObject temp = Instantiate(DungeonManager.instance.roomPrefabs[roomCount], transform.position, Quaternion.identity);
            DungeonManager.instance.RoomsObjecs.Add(temp);
            DungeonManager.instance.CurrentRooms.Add(transform.position);
        }
        else
        {
            tp.SetActive(false);
        }
    }

}
