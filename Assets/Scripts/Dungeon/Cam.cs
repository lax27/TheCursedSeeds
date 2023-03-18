using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform cam;
    public string direcion;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && direcion == "up")
        {
            cam.transform.position += new Vector3(0, 10, 0);
            player.transform.position += new Vector3(0, 5, 0);
        }
    }

}
