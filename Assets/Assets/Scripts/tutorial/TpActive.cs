using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpActive : MonoBehaviour
{
    public GameObject Teacher;
    public GameObject Teleport;
    private Animator Teleport_t;
    private BoxCollider2D coll;
    private SpriteRenderer t;
    // Start is called before the first frame update
    void Start()
    {
        t = Teacher.GetComponent<SpriteRenderer>();

        Teleport_t = Teleport.GetComponent<Animator>();
        Teleport_t.enabled = false;

        coll = Teleport.GetComponent<BoxCollider2D>();
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(t.enabled == false)
        {
            coll.enabled = true;
            Teleport_t.enabled = true;
        }
    }
}
