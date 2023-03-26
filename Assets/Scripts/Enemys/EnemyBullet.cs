using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private Vector2 dir;
    public BulletStats bs;
    private GameObject p;
    private Transform target;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      bs = GetComponent<BulletStats>();
      p = GameObject.Find("mantee_v2");
      target = p.GetComponent<Transform>();

        dir = target.transform.position - transform.position;
        rb.velocity = dir.normalized * bs.speed;
    }
}
