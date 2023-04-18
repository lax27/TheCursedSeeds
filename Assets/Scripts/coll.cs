using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coll : MonoBehaviour
{
    private BoxCollider2D col;
    private  bool isvalid = false;
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isvalid);

        if(isvalid && Input.GetButtonDown("interaction"))
        {
            Debug.Log("Valid");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isvalid = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isvalid = false;
    }
}