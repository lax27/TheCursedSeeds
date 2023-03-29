using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shells : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float timer = 0.5f;
    private Vector2 dir;
    private RotatePoint rp;
    private GameObject rotatepoint;
    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        rotatepoint = GameObject.Find("RotatePoint");
        rp = rotatepoint.GetComponent<RotatePoint>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();


        dir = -rp.mousePos.normalized * 10;//funciona mal, dependidendo lo lejos que este el raton van mas lejos o mas cerca
    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rp.mousePos);


        timer -= Time.deltaTime;

        if (timer <= 0.35f)
        {
            sp.sortingLayerName = "ice cube";
            rb.gravityScale = 100;
        }
        if (timer <= 0)
        {
            sp.sortingLayerName = "details";
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(dir ,ForceMode2D.Impulse);
    }
}
