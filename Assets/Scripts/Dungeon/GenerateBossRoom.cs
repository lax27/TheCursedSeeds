using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBossRoom : MonoBehaviour
{


    private void Update()
    {
        

        if (DungeonManager.instance.bossBugsRooms.Count < 1 )
        {
            DungeonManager.instance.SpawnBossRoom();
        }
        
        if(DungeonManager.instance.bossBugsRooms.Count > 1)
        {
            Destroy(this);
        }

    }
}
