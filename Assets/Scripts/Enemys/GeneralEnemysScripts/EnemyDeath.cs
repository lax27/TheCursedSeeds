using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDeath : MonoBehaviour
{
    EnemysStats es;
    Collider2D cl;
    float timerHit = 0;
    SpriteRenderer sr;
    public bool isHit = false;
    EnemyFreez ef;
    private SimpleFlash flash;
    
    // Start is called before the first frame update
    void Start()
    {
        flash = GetComponent<SimpleFlash>();
        es = GetComponent<EnemysStats>();
        cl = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        ef = GetComponent<EnemyFreez>();
    }

    // Update is called once per frame
    void Update()
    {
        if (es.life <= 0) {
            GetComponent<LootBag>().InstatianteWseed(transform.position);
            Destroy(gameObject);
        }


        if (isHit)
        {
            timerHit -= Time.deltaTime;
            if (timerHit < 0.5f)
            {
                isHit = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("bullet"))
        {
            BulletStats bs;
            bs = collision.GetComponent<BulletStats>();
            Destroy(collision.gameObject);
            timerHit = 1;
            flash.FlashP(0.25f);
            isHit = true;
            es.life -= bs.damage;
        }
    }
}
