using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClamperBulletSpin : MonoBehaviour
{
    private float spinValue = 0;
    [SerializeField]private float spinForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spinValue += spinForce;
        transform.eulerAngles = new Vector3(0, 0, spinValue);
    }
}
