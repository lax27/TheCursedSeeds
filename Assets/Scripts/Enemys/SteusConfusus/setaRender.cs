using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setaRender : MonoBehaviour
{
    ExploSeta ex;
    SpriteRenderer sr;
    GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        explosion = GameObject.Find("explosionP");
        sr.GetComponent<SpriteRenderer>();
        ex = GetComponent<ExploSeta>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
