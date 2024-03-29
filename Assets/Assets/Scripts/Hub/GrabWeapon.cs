using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    private GameObject rotationZone;
    private Rigidbody2D rbWeapon;

    private Vector3 dir;

    public int numChild;
    private bool pickeable = false;
    private float randomForce;
    private float iceTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        randomForce = Random.Range(10f, 25f);
        rotationZone = GameObject.Find("RotatePoint");
        rbWeapon = GetComponent<Rigidbody2D>();
        dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        rbWeapon.AddForce(gameObject.transform.position + dir * randomForce,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        iceTime -= Time.deltaTime;

        if (iceTime <= 0)
        {
            rbWeapon.angularDrag = 0;
            rbWeapon.drag = 0;
            rbWeapon.mass = 0.3f;
        }
        if (pickeable && Input.GetKeyDown(KeyCode.E)) 
        {
            for (int i = 0; i < rotationZone.transform.childCount; i++)
            {
                rotationZone.transform.GetChild(i).gameObject.SetActive(false);
            }

            rotationZone.transform.GetChild(numChild).gameObject.SetActive(true);
            GameManager.instance.currentWeaponID = numChild;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pickeable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pickeable = false;
    }
}
