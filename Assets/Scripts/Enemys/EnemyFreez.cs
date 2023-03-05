using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        es = GetComponent<EnemysStats>();
        sr = GetComponent<SpriteRenderer>();
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

            if (isHit)
            {
                timerHit -= Time.deltaTime;
                if (timerHit < 0.5f)
                {
                    sr.color = Color.blue;
                    isHit = false;
                }
            }
            if (timeToMelt <= 0.0f)
            {
                meltChar();
            }
        }

    }

    private void freezeChar()
    {
        es.speed = 0;
        sr.color = Color.blue;
        isFreez = true;
        timeToMelt = 5.0f;
        setToFreeze = false;

    }

    private void meltChar()
    {
        setToFreeze = false;
        sr.color = Color.white;
        es.speed = 2;
        isFreez = false;
        timeToMelt = 0.0f;
    }
}
