using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStep : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject chest;
    private Animator animation_s;
    void Start()
    {
        animation_s = chest.GetComponent<Animator>();
        animation_s.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animation_s.enabled = true;
    }
}
