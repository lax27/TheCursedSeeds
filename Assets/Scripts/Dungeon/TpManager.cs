using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpManager : MonoBehaviour
{
    public GameObject[] NewsRooms;
    public GameObject[] tp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < NewsRooms.Length; i++)
        {
            if (tp[i] != null)
            {
                if (NewsRooms[i] == DungeonManager.instance.currentRoomsPositions.Contains(NewsRooms[i].transform.position))
                {
                    tp[i].SetActive(true);
                }
            }
        }
    }
}
