using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmove : MonoBehaviour
{
    PlayerStats ps;
    PlayerStatus status;
    LoseGetLife ls;

    private Rigidbody2D rbPlayer;
    private Vector2 direction;
    private Vector3 directionT;

    public float timeK = 0.5f;
    public float KonckBackForce = 10;
    public bool isK = false;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<PlayerStats>();
        status = GetComponent<PlayerStatus>();
        rbPlayer = GetComponent<Rigidbody2D>();
        ls = GetComponent<LoseGetLife>();


    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //condicional para el debuffo de controles invertidos
        if (!status.isConfused) {
            direction = new Vector2(horizontal, vertical).normalized;
            directionT = new Vector2(horizontal, vertical).normalized;
        }
        else {
            direction = new Vector2(vertical,horizontal).normalized;
            directionT = new Vector2(vertical,horizontal).normalized;
        }

        //transform.position += directionT * ps.speed * Time.deltaTime;

        if (isK)
        {
            timeK -= Time.deltaTime;
            if(timeK <= 0)
            {
                isK = false;
                timeK = 0.3f;
            }
        }

 
    }

    private void FixedUpdate()
    {
        if (isK)
        {
            transform.position += ls.direcionEnemy * KonckBackForce * Time.fixedDeltaTime;
        }
        else if (!isK)
        {
            transform.position += directionT * ps.speed * Time.fixedDeltaTime;
        }
    }
}
