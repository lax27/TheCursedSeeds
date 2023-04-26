using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPlayerTouch : MonoBehaviour
{

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
