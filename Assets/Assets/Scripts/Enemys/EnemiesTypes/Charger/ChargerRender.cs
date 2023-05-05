using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerRender : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    EnemyDeath enemyDeath;
    ChargerMovement chargerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
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


          
        //Debug.Log(magnitude);
        //if (magnitude > 0)
        //{
        //    sr.flipX = true;
        //}
        //else if (magnitude < 0)
        //{
        //    sr.flipX = false;
        //}

    }
}
