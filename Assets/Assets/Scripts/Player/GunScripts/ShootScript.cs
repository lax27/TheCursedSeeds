using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootScript : MonoBehaviour
{
    //ShootLogic
    public GameObject bullet;
    public bool canFire;
    private float timer;
    public float timeBetwenFire;

    //ammo logic
    public int currentAmmo = 12;
    public int maxAmmo = 6;
    private float reloadTime;
    public float reloadTimeOffset;
    public bool isReloading = false;

    //FedBack
    [SerializeField]private AudioClip sound;
    public Transform canon = null;
    private Animator animator;
    private CameraShake shake;
    public GameObject shells;

    //Script with the shoot code
    private ShotingTypesFunctions shotFunctions;

    //script with the move code
    private PlayerMovement playerMove;
    private PlayerStats playerStats;
    private float normalspeedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.Find("mantee_v2").GetComponent<PlayerMovement>();
        playerStats = GameObject.Find("mantee_v2").GetComponent<PlayerStats>();
        shotFunctions = GetComponent<ShotingTypesFunctions>();
        shake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        animator = GetComponent<Animator>();    
        canFire = true;
        reloadTime = reloadTimeOffset;
        normalspeedPlayer = playerStats.speed;

    }

    // Update is called once per frame
    void Update()
    {
        playerStats.speed = normalspeedPlayer;
       
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetwenFire)
            {
                playerMove.isShooting = false;
                canFire = true;
                timer = 0;
            }
        }

        
        if (Input.GetMouseButton(0) && canFire && currentAmmo != 0 && !isReloading)
        {
           canFire = false;

            if (gameObject.name == "BasicGun")
            {
                 playerMove.isShooting = true;
                 shotFunctions.BasicShoot(bullet, sound, animator, shells, shake, gameObject, canon, 0.05f, 0.12f, 5f);
                 currentAmmo--;
            }

            if (gameObject.name == "rabbit")
            {
                playerMove.isShooting = true;
                shotFunctions.Rafaga(bullet, sound, animator, shells, shake, gameObject, canon, 0.1f, 0.15f, 6f,playerMove);
                currentAmmo--;
            }

            if (gameObject.name == "ShotGun")
            {
                playerMove.isShooting = true;
                shotFunctions.Shootgun(bullet, sound, animator, shells, shake, gameObject, canon, 0.12f, 0.15f);
                currentAmmo--;
            }

            //if (gameObject.name == "MachineGun")
            //{
            //    playermove.speed = 0;
            //    shotFunctions.MachineGun(bullet, sound, animator, shells, shake, gameObject, canon, 0.02f, 0.10f, bulletCount);
            //    currentAmmo--;
            //    bulletCount++;
            //}
        }
       
        if (Input.GetKeyDown(KeyCode.R) || currentAmmo <= 0)
        {
            isReloading = true;
            if(gameObject.name == "BasicGun")
            {
                animator.SetTrigger("Reloading");
                animator.SetBool("idle", false);
            }

            if(gameObject.name == "rabbit")
            {
                animator.SetTrigger("Reloading");
                animator.SetBool("idle", false);
            }
        }

        if (isReloading)
        {
            //animacion de recarga
            reloadTime -= Time.deltaTime;
            if (reloadTime <= 0)
            {
                isReloading = false;
                currentAmmo = maxAmmo;
                reloadTime = reloadTimeOffset;

                animator.ResetTrigger("Reloading");
                animator.SetBool("idle", true);
            }
        }
    }
}
