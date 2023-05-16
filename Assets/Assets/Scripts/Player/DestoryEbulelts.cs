using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEbulelts : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyB")
        {
            Destroy(collision.gameObject);
        }
    }
}
