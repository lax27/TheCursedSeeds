using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Room : MonoBehaviour
{
    public GameObject Bee_1;
    public GameObject Bee_2;
    public GameObject sus;

    public GameObject Teleport;
    private Animator a;
    private BoxCollider2D coll;

    private int counter;
    

    // Start is called before the first frame update
    void Start()
    {
        a = Teleport.GetComponent<Animator>();
        coll = Teleport.GetComponent<BoxCollider2D>();

        a.enabled = false;
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Bee_1 == null && Bee_2 == null && sus == null)
        {
            a.enabled = true;
            coll.enabled = true;
        }
    }
}
