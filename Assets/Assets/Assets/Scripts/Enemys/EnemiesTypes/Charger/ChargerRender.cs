using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerRender : MonoBehaviour
{
    private GameObject player;
    SpriteRenderer sr;
    Animator animator;
    EnemyDeath enemyDeath;
    ChargerMovement chargerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mantee_v2");
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        enemyDeath = GetComponent<EnemyDeath>();
        chargerMovement = GetComponent<ChargerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDeath.isHit)
        {
            animator.SetBool("isHitA", true);
        }
        else
        {
            animator.SetBool("isHitA", false);
        }
        if (chargerMovement.isCharging)
        {
            animator.SetBool("isCharginA", true);
        }
        else
        {
            animator.SetBool("isCharginA", false);
        }

        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
          
      

    }
}
