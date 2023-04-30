using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlantZone : MonoBehaviour
{
    private Collider2D cl;
    private PlayerStats pm;
    private ShootScript sh;
    public bool inRange = false;
    public GameObject plantMenu;
    public GameObject Guns;
    public GameObject press;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        sr = press.GetComponent<SpriteRenderer>();
        sr.enabled = false;

        pm = GameObject.Find("mantee_v2").GetComponent<PlayerStats>();
        sh = GameObject.Find("mantee_v2").GetComponent<ShootScript>();
        cl = GetComponent<Collider2D>();
        rb = GameObject.Find("mantee_v2").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {



        if (inRange)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }

        //mejorar esto para que solo se abra con la e y se cierre otra vez pulsando e
        if (Input.GetButtonDown("interaction") && inRange && GameManager.instance.isWeapon == false)
        {
            press.SetActive(false);
            //desactivar el movimento
            pm.speed = 0;

            rb.mass = 1231231;

            //desactivar el disparo
            Guns.SetActive(false);
            //activar el menu de platado   
            plantMenu.SetActive(true);
        }
        if (pm.speed == 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            press.SetActive(true);
            pm.speed = 5;
            rb.mass = 1;
            Guns.SetActive(true);
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