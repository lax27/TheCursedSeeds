using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject cam;
    public string direction;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("CameraFollow");
        player = FindObjectOfType<PlayerStats>().transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            if (direction == "up")
            {
                cam.transform.position += new Vector3(0, 12.38f, 0);
                player.transform.position += new Vector3(0, 6.4f, 0);
            }

            else if (direction == "down")
            {
                cam.transform.position += new Vector3(0, -12.48f, 0);
                player.transform.position += new Vector3(0, -6.4f, 0);
            }

            else if(direction == "right")
            {
                cam.transform.position += new Vector3(22, 0, 0);
                player.transform.position += new Vector3(3f, 0, 0);
            }

            else if (direction == "left")
            {
                cam.transform.position += new Vector3(-22, 0, 0);
                player.transform.position += new Vector3(-3f, 0, 0);
            }

            AutoConfigMinimapMask.ConfigurarRenderers();

        }

    }

}
