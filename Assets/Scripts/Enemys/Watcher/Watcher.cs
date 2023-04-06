using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour
{
    public float rotationSpeed;
    public float visionDistance;
    public LineRenderer LineOfSight;

    private bool canFire = false;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LineOfSight.SetPosition(0, transform.position);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, visionDistance);
        if (hitInfo.collider != null)
        {

            if (hitInfo.collider.tag == "Player")
            {
                Debug.Log("aaaaaaaaa");
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

            if (canFire)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
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
