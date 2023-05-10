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
    private GameObject player;
    private Transform p;
    public Vector3 randomBullet;
    public Vector3 direcion;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mantee_v2");
        rb = GetComponent<Rigidbody2D>();
        bs = GetComponent<BulletStats>();
        p = player.GetComponent<Transform>();

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        direcion = (mousePos - p.transform.position).normalized; // el vector desde el objeto hacia el mouse
        randomBullet = Quaternion.Euler(0f, 0f, Random.Range(-dispersionAngle, dispersionAngle)) * direcion; // cambio de direcion para que el arma tenga dispersion
        Vector3 rotation = transform.position - mousePos; // la rotacion enemiesStats para que la bala siempre se vea recta enemyDeath todos los angulos respecto al mouse

        rb.velocity = new Vector2(randomBullet.x, randomBullet.y).normalized * bs.speed;  
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }
}
