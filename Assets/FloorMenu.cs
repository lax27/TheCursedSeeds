using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMenu : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private GameObject portal;
    private GoToDungeon goToDungeon;
    // Start is called before the first frame update
    void Start()
    {
        portal = GameObject.Find("dungeonTp");
        goToDungeon = portal.GetComponent<GoToDungeon>();
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToHub()
    {
        player.SetActive(true);
        gameObject.SetActive(false);
        Collider2D collD = portal.GetComponent<Collider2D>();
        collD.enabled = false;

        goToDungeon.inPortal = false;
    }
}
