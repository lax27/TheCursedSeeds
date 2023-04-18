using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shells;
    public bool canFire;
    private float timer;
    public float timeBetwenFire;
    [SerializeField]private AudioClip sound;
    public Transform canon = null;
    Collider2D coll;
    private GameObject cannon;
    private Animator anim;

    private GameObject camera;
    private CamaraShake shake;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        shake = camera.GetComponent<CamaraShake>(); 
        cannon = GameObject.Find("Canon");
        //anim = cannon.GetComponent<Animator>();
        canFire = true;
        coll = bullet.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
   

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetwenFire)
            {
                //anim.SetBool("Shoot", false);
                canFire = true;
                timer = 0;
            }
        }



        if (Input.GetMouseButton(0) && canFire)
        {

            canFire = false;
            if (gameObject.name == "BasicGun")
            {
                //Iniciar animacion de disparo
                //anim.SetBool("Shoot", true);
                //Hacer sonido de disparo
                SoundController.instance.PlaySound(sound);
                //Casquillos
                Instantiate(shells, transform.position, Quaternion.identity);
                //Camerashake
                shake.CameraShake(0.01f, 0.12f);
                //Spawn de la bala
                GameObject temp = Instantiate(bullet, canon.position, Quaternion.identity);
            }
            if (gameObject.name == "ShotGun")
            {
                //hacer sonido de disparo
                //instacniar casiquillos
                //camerashake
                GameObject temp = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp2 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp3 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp4 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp5 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp6 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp7 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp8 = Instantiate(bullet, canon.position, Quaternion.identity);

            }
        }
    }
}
