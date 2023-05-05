using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBossRoom : MonoBehaviour
{
    private const int MAX_ROOMS = 1;
    // Start is called before the first frame update
    void Start()
    {

       
       bool canGenerate = false;

        if (canGenerate)
        {
            GameObject temp = Instantiate(DungeonManager.instance.bossRoomPrefabs[0], transform.position, Quaternion.identity);
            temp.name = "Boss" + DungeonManager.instance.bossRoomBugs.Count;
            DungeonManager.instance.bossRoomBugs.Add(temp);
        }
    }
}
