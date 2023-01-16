using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private SpriteRenderer rs;

    public List<Sprite> sprites;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rs = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); 

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(rotZ > 90 || rotZ < -90)
        {
            rs.flipX = true;
        }else if (rotZ < 90 || rotZ > -90)
        {
            rs.flipX = false;
        }

        if(rotZ > -135 && rotZ < -45){
            rs.sprite = sprites[2];
        }else if(rotZ > 45 && rotZ < 135){
            rs.sprite = sprites[1];
        } else{
            rs.sprite = sprites[0];
        }

    }
}
