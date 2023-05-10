using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTwo : MonoBehaviour
{
    public GameObject Bee;
    public GameObject Teleport;
    private GameObject cube;

    private Animator a;
    private BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        a = Teleport.GetComponent<Animator>();
        a.enabled = false;

        coll = Teleport.GetComponent<BoxCollider2D>();
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Bee == null)
        {
            a.enabled = true;
            coll.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetButtonDown("interaction")){


        }
    }
}
