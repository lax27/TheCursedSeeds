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
        }
        else {
            direction = new Vector2(vertical,horizontal).normalized;
        }
        
    }

    private void FixedUpdate()
    {
        rbPlayer.MovePosition(rbPlayer.position + direction * ps.speed * Time.fixedDeltaTime);
        //rbPlayer.AddForce(direction * ps.speed * Time.fixedDeltaTime);
    }
}
