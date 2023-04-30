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
    public Vector3 directionKnockedBack;

    private PlayerAimWeapon playerAim;
    public bool isShooting = false;
    private Vector3 KnockBackDir;
    public float knockBackForce;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        status = GetComponent<PlayerStatus>();
        rbPlayer = GetComponent<Rigidbody2D>();
        playerHealthHandler = GetComponent<PlayerHealthHandler>();
        playerAim = GameObject.Find("RotatePoint").GetComponent<PlayerAimWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isShooting);

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

        if (GameManager.instance.currentWeaponID == 0)
        {
            knockBackForce = 500f;
        }

    }

    
    private void FixedUpdate()
    {
       transform.position += direction * playerStats.speed * Time.fixedDeltaTime;

        if (isShooting)
        {
            KnockBackDir = (gameObject.transform.position - playerAim.mousePos).normalized;
            rbPlayer.AddForce(KnockBackDir * knockBackForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
}
