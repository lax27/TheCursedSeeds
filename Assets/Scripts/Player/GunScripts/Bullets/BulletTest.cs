using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public Vector2 DispersionRange;
    Rigidbody2D rb;
    Camera mainCam;
    Vector3 mousePos;
    private float randomAngle;
    private float sen;
    private float cos;
    public BulletStats bs;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bs = GetComponent<BulletStats>();
        



        randomAngle = Random.Range(DispersionRange.x, DispersionRange.y);
        float angle = Mathf.Deg2Rad * randomAngle;
        sen = Mathf.Sin(angle) * 2.5f;  //3; ;
        cos = Mathf.Cos(angle) * 2.5f; //3;
        Vector3 randomDir = new Vector3(cos, sen, 0);


        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direcion = mousePos - transform.position; // el vector desde el objeto hacia el mouse
        Vector3 randomBullet = direcion + randomDir;      // cambio de direcion para que el arma tenga dispersion
        Vector3 rotation = transform.position - mousePos; // la rotacion es para que la bala siempre se vea recta en todos los angulos respecto al mouse

        rb.velocity = new Vector2(randomBullet.x, randomBullet.y).normalized * bs.speed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }


    // Update is called once per frame
    void Update()
    {
       
        
    }
}
