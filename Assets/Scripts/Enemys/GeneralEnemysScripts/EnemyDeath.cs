using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDeath : MonoBehaviour
{
    private EnemysStats enemyStats;
    public float timerHit = 0;
    public bool isHit = false;
    private SimpleFlash flash;
    EnemyFreez ef;
    
    // Start is called before the first frame update
    void Start()
    {
        flash = GetComponent<SimpleFlash>();
        enemyStats = GetComponent<EnemysStats>();
        ef = GetComponent<EnemyFreez>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyStats.life <= 0) {
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
            flash.FlashP(0.2f);

            isHit = true;
            enemyStats.life -= bs.damage;
        }
    }
}
