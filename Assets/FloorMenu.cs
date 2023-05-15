using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorMenu : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private GameObject portal;
    private GoToDungeon goToDungeon;
    [SerializeField]private List<GameObject> buttons = new List<GameObject>();   
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
        if (GameManager.instance.floor1Passed)
        {
            buttons[0].SetActive(true);
        }
        else
        {
            //renderizar un sprite con el boton con un candado
            buttons[0].SetActive(false);
        }

        if (GameManager.instance.floor1Passed && GameManager.instance.floor2Passed)
        {
            buttons[1].SetActive(true);
        }
        else
        {
            //renderizar un sprite con el boton con un candado
            buttons[1].SetActive(false);
        }

        if (GameManager.instance.floor1Passed && GameManager.instance.floor2Passed && GameManager.instance.floor3Passed)
        {
            buttons[2].SetActive(true);
        }
        else
        {
            //renderizar un sprite con el boton con un candado
            buttons[2].SetActive(false);
        }

        if (GameManager.instance.floor1Passed && GameManager.instance.floor2Passed && GameManager.instance.floor3Passed && GameManager.instance.bossPassed)
        {
            buttons[3].SetActive(true);
        }
        else
        {
            //renderizar un sprite con el boton con un candado
            buttons[3].SetActive(false);
        }

    }

    public void ReturnToHub()
    {
        player.SetActive(true);
        gameObject.SetActive(false);
        Collider2D collD = portal.GetComponent<Collider2D>();
        collD.enabled = false;

        goToDungeon.inPortal = false;
    }

    public void GoToDungeon(int floorNumber)
    {
        GameManager.instance.currentFloor = floorNumber;
        SceneManager.LoadScene("GameplayDefinitivoTest");
    }
}
