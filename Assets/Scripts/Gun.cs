using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private SpriteRenderer rs;
    public RotatePoint rp;
    // Start is called before the first frame update
    void Start()
    {
        rs = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rp.transform.localEulerAngles.z > 45 && rp.transform.localEulerAngles.z < 135)
        {
            rs.sortingOrder = 0;
        }
        else
        {
            rs.sortingOrder = 2;
        }
    }
}
