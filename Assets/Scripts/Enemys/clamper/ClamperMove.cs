using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClamperMove : MonoBehaviour
{
    private Vector3 dir;
    private bool stoped = true;
    private bool move = false;
   [SerializeField] private float timer = 5;
    [SerializeField ]private float timerM = 1f;
    // Start is called before the first frame update
    private EnemysStats es;
    void Start()
    {
        es = GetComponent<EnemysStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stoped)
        {
            dir = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360)).normalized;
        }

        if (stoped)
        {
            timerM = 1f;
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            stoped = false;
            move = true;
        }

        if (move)
        {
            timer = 5;
            timerM -= Time.deltaTime;
        }


        if (timerM <= 0)
        {
            stoped = true;
            move = false;
        }

    }

    private void FixedUpdate()
    {
        if (move)
        {
            transform.position += dir * es.speed * Time.fixedDeltaTime;
        }
    }
}
