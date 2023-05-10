using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpUI : MonoBehaviour
{
    private GameObject player;
    private PlayerStats playerStats;
    private PlayerHealthHandler healthHandler;
    public GameObject[] lifesIcons;
    public GameObject[] noLifesIcons;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mantee_v2");
        playerStats = player.GetComponent<PlayerStats>();
        healthHandler = player.GetComponent<PlayerHealthHandler>();
        for (int i = 0; i < lifesIcons.Length; i++)
        {

            Image life = lifesIcons[i].GetComponent<Image>();
            life.color = new Color(255, 255, 255, 0.1f); 

            Image noLife = noLifesIcons[i].GetComponent<Image>();
            noLife.color = new Color(255, 255, 255, 0.1f); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.life <= 0)
        {
            lifesIcons[0].SetActive(false);
            lifesIcons[1].SetActive(false);
            lifesIcons[2].SetActive(false);
        }

        if (playerStats.life == 1)
        {
            lifesIcons[1].SetActive(false);
            lifesIcons[2].SetActive(false);
        }

        if (playerStats.life == 2)
        {
            lifesIcons[2].SetActive(false);
        }
    }
}
