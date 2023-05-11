using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToDungeon : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject floorMenu;
    public bool inPortal = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mantee_v2");
    }

    // Update is called once per frame
    void Update()
    {
        if (inPortal) {
            player.SetActive(false);
            floorMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Player")
        //{
        //    SceneManager.LoadScene("GameplayDefinitivoTest");
        //}
        if (collision.tag == "Player")
        {
            inPortal = true;   
        }
    }
}
