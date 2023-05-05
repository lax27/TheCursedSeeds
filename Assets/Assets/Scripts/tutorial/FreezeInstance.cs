using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeInstance : MonoBehaviour
{
    public GameObject Bee;
    private Animator a;

    public GameObject Teleport;
    private Animator t;
    private BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        a = Bee.GetComponent<Animator>();
        a.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
