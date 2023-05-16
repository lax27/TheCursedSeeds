using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlantZone : MonoBehaviour
{
    private PlayerStats playerStats;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private PauseMenu pauseMenu;
    public GameObject plantMenu;
    public GameObject guns;
    public GameObject press;
    public GameObject growing;

    public bool plantMenuActive = false;
    public bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = press.GetComponent<SpriteRenderer>();
        sr.enabled = false;
        pauseMenu = GameObject.Find("pauseMenu").GetComponent<PauseMenu>();
        playerStats = GameObject.Find("mantee_v2").GetComponent<PlayerStats>();
        rb = GameObject.Find("mantee_v2").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(plantMenuActive);
        if (inRange)
        {
            sr.enabled = true;
        }

        else
        {
            sr.enabled = false;
        }

        if (GameManager.instance.isPlanted)
        {
            growing.SetActive(true);
        }

        else
        {
            growing.SetActive(false);
        }

        //mejorar esto para que solo se abra con la e y se cierre otra vez pulsando e
        if (Input.GetKeyDown(KeyCode.E) && inRange && !GameManager.instance.isPlanted && !pauseMenu.isActive && !plantMenuActive)
        {
            plantMenuActive = true;
            press.SetActive(false);

            //desactivar el movimento
            playerStats.speed = 0;

            rb.mass = 1231231;

            //desactivar el disparo
            guns.SetActive(false);

            //activar el menu de platado   
            plantMenu.SetActive(true);
        }

        else if (playerStats.speed == 0 && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E) && !pauseMenu.isActive && plantMenuActive)
        {
            plantMenuActive = false;
            press.SetActive(true);
            playerStats.speed = 5;
            rb.mass = 1;
            guns.SetActive(true);
            plantMenu.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
        }
    }
}