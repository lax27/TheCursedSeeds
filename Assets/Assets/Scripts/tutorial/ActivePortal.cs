using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePortal : MonoBehaviour
{
    public GameObject Active_Portal;
    private Animator a;

    // Start is called before the first frame update
    void Start()
    {
        a = Active_Portal.GetComponent<Animator>();
        a.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(a.enabled == false)
        a.enabled = true;
    }
}
