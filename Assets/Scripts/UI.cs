using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public List<Image> lifes;
    public GameObject playerManager;
    private PlayerManager player;
    // Start is called before the first frame update
    void Start()
    {
       playerManager = GameObject.Find("PlayerManager");
        if (playerManager != null)
        {
            player = playerManager.GetComponent<PlayerManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
  
        if(player.life == 2)
        {
            
        }

    }
}
