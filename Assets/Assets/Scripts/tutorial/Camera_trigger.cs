using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_trigger : MonoBehaviour
{

    public GameObject Bee_1;
    public GameObject Bee_2;
    public GameObject sus;

    private SpriteRenderer S;
    private SpriteRenderer S2;
    private SpriteRenderer S3;

    private ClamperMovement movement1;
    private ChargerMovement movement2;
    private ChargerMovement movement3;
    private ClamperShoot shoot;



    // Start is called before the first frame update
    void Start()
    {

        S = Bee_1.GetComponent<SpriteRenderer>();
        S2 = Bee_2.GetComponent<SpriteRenderer>();
        S3 = sus.GetComponent<SpriteRenderer>();

        S.enabled = false;
        S3.enabled = false;
        S2.enabled = false;

        movement2 = Bee_1.GetComponent<ChargerMovement>();
        movement3 = Bee_2.GetComponent<ChargerMovement>();
        movement1 = sus.GetComponent<ClamperMovement>();

        shoot = sus.GetComponent<ClamperShoot>();

        movement1.enabled = false;
        movement2.enabled = false;
        movement3.enabled = false;
        shoot.enabled = false;




    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            S.enabled = true;
            S3.enabled = true;
            S2.enabled = true;
            movement1.enabled = true;
            movement2.enabled = true;
            movement3.enabled = true;
            shoot.enabled = true;

        }
        else if (collision.CompareTag("seta"))
        {
            S.enabled = true;
            S3.enabled = true;
            S2.enabled = true;
            movement1.enabled = true;
            movement2.enabled = true;
            movement3.enabled = true;
            shoot.enabled = true;

        }

    }
}
