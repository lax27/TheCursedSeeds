using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    PlayerStats playerStats;
    PlayerStatus status;
    PlayerHealthHandler playerHealthHandler;

    private Rigidbody2D rbPlayer;

    private Vector3 direction;

    public const float KNOCK_BACK_DURATION = 0.5f;
    public float konckBackTimer = KNOCK_BACK_DURATION;
    public float konckBackForce = 10f;
    public bool beingKnockedBack = false;

    public Vector3 directionKnockedBack;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        status = GetComponent<PlayerStatus>();
        rbPlayer = GetComponent<Rigidbody2D>();
        playerHealthHandler = GetComponent<PlayerHealthHandler>();


    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMoveInput;
        float verticalMoveInput;
        //condicional para el debuffo de controles invertidos
        if (!status.isConfused) {
             horizontalMoveInput = Input.GetAxisRaw("Horizontal");
             verticalMoveInput = Input.GetAxisRaw("Vertical");
        }
        else {
            horizontalMoveInput = -Input.GetAxisRaw("Horizontal");
            verticalMoveInput = -Input.GetAxisRaw("Vertical");
        }

        direction = new Vector2(horizontalMoveInput, verticalMoveInput).normalized;
        
        if (beingKnockedBack)
        {
            konckBackTimer -= Time.deltaTime;
            if(konckBackTimer <= 0)
            {
                beingKnockedBack = false;
                konckBackTimer = KNOCK_BACK_DURATION;
            }
        }
    }

    /*
     Nota:
    Cambiar transform position desde código se usa solo para casos muy especiales
    para este caso lo habitual sería usar rbPlayer.velocity = direction * speed enemyDeath el update
    para así aprovechar las físicas de unity enemyDeath lugar de sobreescribir la posición.
     */
    private void FixedUpdate()
    {
        if (beingKnockedBack)
        {
            transform.position += directionKnockedBack * konckBackForce * Time.fixedDeltaTime;
        }
        else
        {
            transform.position += direction * playerStats.speed * Time.fixedDeltaTime;
        }
    }
}
