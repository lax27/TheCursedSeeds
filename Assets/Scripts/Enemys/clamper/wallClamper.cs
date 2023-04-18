using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallClamper : MonoBehaviour
{
    private ClamperMove mv;
    private Collider2D cl;
    private GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        mv = GetComponentInParent<ClamperMove>();
        wall = GameObject.Find("wall");
        cl = wall.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
        {
            mv.dir = mv.dir - mv.transform.position;
            mv.dir = mv.dir.normalized;
            mv.move = true;
            mv.stoped = false;
        }
    }
}
