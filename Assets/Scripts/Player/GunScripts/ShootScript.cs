using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    //ShootLogic
    public GameObject bullet;
    public bool canFire;
    private float timer;
    public float timeBetwenFire;
    private int bulletCount;

    //FedBack
    [SerializeField]private AudioClip sound;
    public Transform canon = null;
    private Animator animator;
    private CameraShake shake;
    public GameObject shells;

    //Script with the shoot code
    private ShotingTypesFunctions shotFunctions;

    // Start is called before the first frame update
    void Start()
    {
        shotFunctions = GetComponent<ShotingTypesFunctions>();
        shake = Camera.main.GetComponent<CameraShake>(); 
        canFire = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetwenFire)
            {
                canFire = true;
                timer = 0;
            }
        }


        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            if (gameObject.name == "BasicGun")
            {
                shotFunctions.BasicShoot(bullet, sound, animator, shells, shake, gameObject, canon, 0.05f, 0.12f);
            }

            if (gameObject.name == "ShotGun")
            {
                shotFunctions.Shootgun(bullet, sound, animator, shells, shake, gameObject, canon, 0, 0);
            }

            //if (gameObject.name == "MachineGun")
            //{
            //    shotFunctions.MachineGun(bullet, sound, animator, shells, shake, gameObject, canon, 0.02f, 0.10f, bulletCount);
            //    bulletCount++;
            //}
        }

        if (!Input.GetMouseButton(0))
        {
            bulletCount = 0;
        }
    }
}
