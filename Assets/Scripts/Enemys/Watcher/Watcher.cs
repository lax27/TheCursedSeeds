using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour
{
    public float rotationSpeed;
    public float visionDistance;
    public LineRenderer LineOfSight;
    public float timer;
    public AudioSource audioS;

    private bool canFire = false;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;


        LineOfSight.SetPosition(0, transform.position);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, visionDistance);
        if (hitInfo.collider != null)
        {

            if (hitInfo.collider.tag == "Player")
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                LineOfSight.SetPosition(1, hitInfo.point);
                LineOfSight.startColor = Color.red;
                LineOfSight.endColor = Color.red;
                canFire = true;
            }
            else
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.green);
                LineOfSight.SetPosition(1, hitInfo.point);
                LineOfSight.startColor = Color.green;
                LineOfSight.endColor = Color.green;
            }

            if (canFire && timer <= 0)
            {
                timer = 0.5f;
                Instantiate(bullet, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.10f), gameObject.transform.rotation);
                audioS.Play();
                canFire = false;
            }

        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * visionDistance, Color.green);
            LineOfSight.SetPosition(1, transform.position + transform.right * visionDistance);
            LineOfSight.startColor = Color.green;
            LineOfSight.endColor = Color.green;
        }
    }
}
