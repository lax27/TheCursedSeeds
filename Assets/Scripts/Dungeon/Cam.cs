using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private GameObject c;
    public Transform cam;
    public string direcion;
    private GameObject p;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        c = GameObject.Find("Main Camera");
        cam = c.GetComponent<Transform>();

        p = GameObject.Find("mantee_v2");
        player = p.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && direcion == "up")
        {
            cam.transform.position += new Vector3(0, 12.48f, 0);
            player.transform.position += new Vector3(0, 7, 0);
        }

        if (collision.tag == "Player" && direcion == "down")
        {
            cam.transform.position += new Vector3(0, -12.48f, 0);
            player.transform.position += new Vector3(0, -7, 0);
        }

        if(collision.tag == "Player" && direcion == "right")
        {
            cam.transform.position += new Vector3(22, 0, 0);
            player.transform.position += new Vector3(6.80f, 0, 0);
        }

        if (collision.tag == "Player" && direcion == "left")
        {
            cam.transform.position += new Vector3(-22, 0, 0);
            player.transform.position += new Vector3(-6.80f, 0, 0);
        }

    }

}
