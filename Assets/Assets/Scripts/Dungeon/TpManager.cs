using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpManager : MonoBehaviour
{
    public GameObject[] newRooms;
    public GameObject[] tp;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < newRooms.Length; i++)
        {
            if (tp[i] != null)
            {
                if (newRooms[i] == DungeonManager.instance.currentRoomsPositions.Contains(newRooms[i].transform.position))
                {
                    tp[i].SetActive(true);
                }
            }
        }
    }
}
