using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer test;
    public float R;
    public float G;
    public float B;
    public float A;


    public  bool valid;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (valid)
        {
                         test.material.color = new Color(
                         R  / 255.0f,
                         G  / 255.0f,
                         B  / 255.0f,
                         A  / 255.0f);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        valid = true;
    }
}
