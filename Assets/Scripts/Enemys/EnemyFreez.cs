using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFreez : MonoBehaviour
{
    public bool isFreez = false;
    public bool setToFreeze = false;
    private SpriteRenderer sr;
    private float timerHit;
    EnemysStats es;
    public bool isHit = false;
    private float timeToMelt = 0.0f;

    // 
    GameObject cubito;
    private SpriteRenderer srCubito;
    // Start is called before the first frame update
    void Start()
    {
        es = GetComponent<EnemysStats>();
        sr = GetComponent<SpriteRenderer>();
        cubito = GameObject.Find("ice_cube");
        srCubito = cubito.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (setToFreeze)
        {
            freezeChar();
        }
       if (isFreez)
        {
            timeToMelt -= Time.deltaTime;

            if (timeToMelt <= 0.0f)
            {
                meltChar();
            }
        }

    }

    private void freezeChar()
    {
        es.speed = 0;
        srCubito.enabled = true;
        isFreez = true;
        timeToMelt = 5.0f;
        setToFreeze = false;

    }

    private void meltChar()
    {
        setToFreeze = false;
        srCubito.enabled = false;
        es.speed = 2;
        isFreez = false;
        timeToMelt = 0.0f;
    }
}
