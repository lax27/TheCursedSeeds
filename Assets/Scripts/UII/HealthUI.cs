using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{

    public GameObject[] healthUIIcons;


    // Update is called once per frame
    void Update()
    {



        for (int i = 0; i < healthUIIcons.Length; i++)
        {
            healthUIIcons[i].SetActive(PlayerStats.instance.playerHealth > i);
        }

    }
}
