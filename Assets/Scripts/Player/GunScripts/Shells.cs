using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shells : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float timer = 0.5f;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = new Vector2(Random.Range(-5, 5), transform.up.y);
    }

    // Update is called once per frame
    void Update()
    {


        timer -= Time.deltaTime;

        if (timer <= 0.35f)
        {
            rb.gravityScale = 100;
        }
        if (timer <= 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(dir,ForceMode2D.Impulse);
    }
}
