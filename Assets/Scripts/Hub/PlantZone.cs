using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlantZone : MonoBehaviour
{
    private Collider2D cl;
    private PlayerStats pm;
    private ShootScript sh;
    [SerializeField] private bool inRange = false;
    public GameObject plantMenu;
    public GameObject Guns;
   

    // Start is called before the first frame update
    void Start()
    {
     
        pm = GameObject.Find("mantee_v2").GetComponent<PlayerStats>();
        sh = GameObject.Find("mantee_v2").GetComponent<ShootScript>();
        cl = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //mejorar esto para que solo se abra con la e y se cierre otra vez pulsando e
        if (Input.GetButtonDown("interaction") && inRange)
        {
            //desactivar el movimento
            pm.speed = 0;

            //desactivar el disparo
            Guns.SetActive(false);
            //activar el menu de platado   
            plantMenu.SetActive(true);
        }
        if (pm.speed == 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            pm.speed = 5;
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