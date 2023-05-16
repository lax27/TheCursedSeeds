using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour
{
    public LineRenderer lineOfSight;
    public AudioSource audioSource;
    public GameObject bullet;

    public float rotationSpeed;
    public float visionDistance;
    public float timer;
    private bool canFire = false;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        lineOfSight.SetPosition(0, transform.position);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, visionDistance);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.tag == "Player")
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                lineOfSight.SetPosition(1, hitInfo.point);
                lineOfSight.startColor = Color.red;
                lineOfSight.endColor = Color.red;
                canFire = true;
            }

            else
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.green);
                lineOfSight.SetPosition(1, hitInfo.point);
                lineOfSight.startColor = Color.green;
                lineOfSight.endColor = Color.green;
            }

            if (canFire && timer <= 0)
            {
                timer = 0.5f;
                Instantiate(bullet, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.10f), gameObject.transform.rotation);
                audioSource.Play();
                canFire = false;
            }
        }

        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * visionDistance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.right * visionDistance);
            lineOfSight.startColor = Color.green;
            lineOfSight.endColor = Color.green;
        }
    }
}
