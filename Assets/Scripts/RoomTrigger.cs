using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public float camX;
    public float camY;

    GameObject camara;

    private void Start()
    {
        camara = GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        camara.transform.position = new Vector3(7.38f, 0.19f, -10);
    }
}
