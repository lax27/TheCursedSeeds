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
    public Material vacio;
    public Material lleno;

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

    }

    public void UpdateLife()
    {
        for (int i = 0; i < lifes.Count; i++)
        {
            if (i < player.life)
            {
                lifes[i].material = lleno;
            }
            else
            {
                lifes[i].material = vacio;
            }
        }
    }
}


