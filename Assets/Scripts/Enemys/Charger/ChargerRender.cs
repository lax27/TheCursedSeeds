using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerRender : MonoBehaviour
{
    Animator anim;
    EnemyDeath en;
    MoveCharger mc;
    SpriteRenderer sr;
    Vector3 direcion;
    float magnitude;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        en = GetComponent<EnemyDeath>();
        mc = GetComponent<MoveCharger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (en.isHit)
        {
            anim.SetBool("isHitA", true);
        }
        else
        {
            anim.SetBool("isHitA", false);
        }
        if (mc.isChargin)
        {
            anim.SetBool("isCharginA", true);
        }
        else
        {
            anim.SetBool("isCharginA", false);
        }


        magnitude = mc.dir.magnitude;    
        Debug.Log(magnitude);
        if (magnitude > 0)
        {
            sr.flipX = true;
        }
        else if (magnitude < 0)
        {
            sr.flipX = false;
        }

    }
}
