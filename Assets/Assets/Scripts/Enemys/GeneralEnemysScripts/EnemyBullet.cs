using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private Vector2 dir;
    public BulletStats bulletStats;
    private GameObject player;
    private Transform target;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      bulletStats = GetComponent<BulletStats>();
      player = GameObject.Find("mantee_v2");
      target = player.GetComponent<Transform>();
        
        dir = target.transform.position - transform.position;
        rb.velocity = dir.normalized * bulletStats.speed;
    }

    private void Update()
    {

    }
}
