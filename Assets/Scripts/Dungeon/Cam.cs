using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject cam;
    public string direcion;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
        player = FindObjectOfType<PlayerStats>().transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            if (direcion == "up")
            {
                cam.transform.position += new Vector3(0, 12.48f, 0);
                player.transform.position += new Vector3(0, 7, 0);
            }

            else if (direcion == "down")
            {
                cam.transform.position += new Vector3(0, -12.48f, 0);
                player.transform.position += new Vector3(0, -7, 0);
            }

            else if(direcion == "right")
            {
                cam.transform.position += new Vector3(22, 0, 0);
                player.transform.position += new Vector3(6.80f, 0, 0);
            }

            else if (direcion == "left")
            {
                cam.transform.position += new Vector3(-22, 0, 0);
                player.transform.position += new Vector3(-6.80f, 0, 0);
            }

            AutoConfigMinimapMask.ConfigurarRenderers();

        }

    }

}
