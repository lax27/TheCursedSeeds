using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    PlayerStats playerStats;
    PlayerStatus status;
    public Rigidbody2D rbPlayer;
    private Vector3 direction;
    public Vector3 directionKnockedBack;

    private PlayerAimWeapon playerAim;
    public bool isShooting = false;
    public Vector3 KnockBackDir;
    public float knockBackForce;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        status = GetComponent<PlayerStatus>();
        rbPlayer = GetComponent<Rigidbody2D>();;
        playerAim = GameObject.Find("RotatePoint").GetComponent<PlayerAimWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.life <= 0)
        {
            Destroy(this);
        }
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

        //Retroceso en cada arma
        if (GameManager.instance.currentWeaponID == 0)
        {
            knockBackForce = 400f;
        }
        else if (GameManager.instance.currentWeaponID == 1)
        {
            knockBackForce = 600f;

        }
        else if (GameManager.instance.currentWeaponID == 2)
        {
            knockBackForce = 0f;

        }

    }

    bool isMoving = false;
    
    private void FixedUpdate()
    {
       transform.position += direction * playerStats.speed * Time.fixedDeltaTime;

        if(direction.magnitude != 0)
        {
            if(!isMoving)
            {
                //FoostepsSound.instance.StartPlayFoostepSound();
                isMoving = true;
            }
        }else
        {
            if(isMoving)
            {
                //FoostepsSound.instance.StopMoveSound();
                isMoving = false;
            }
        }

        if (isShooting)
        {
            KnockBackDir = (gameObject.transform.position - playerAim.mousePos).normalized;
            rbPlayer.AddForce(KnockBackDir * knockBackForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
}
