using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNormal : MonoBehaviour
{
    public float dispersionAngle;
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
        

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direcion = mousePos - transform.position; // el vector desde el objeto hacia el mouse
        Vector3 randomBullet = Quaternion.Euler(0f, 0f, Random.Range(-dispersionAngle, dispersionAngle)) * direcion;      // cambio de direcion para que el arma tenga dispersion
        Vector3 rotation = transform.position - mousePos; // la rotacion es para que la bala siempre se vea recta en todos los angulos respecto al mouse

        rb.velocity = new Vector2(randomBullet.x, randomBullet.y).normalized * bs.speed;  //se pone el time.deltaTime
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }


    // Update is called once per frame
    void Update()
    {
       
        
    }
}
