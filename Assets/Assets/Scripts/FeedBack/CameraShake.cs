using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 ogPos;
    public float offsetX = 0.0f;
    public float offsetY = 0.0f;
    public float timeShake = 0.0f;
    public float shakeMagnitude = 0.0f;
    private Vector3 shakePosition = new Vector3();
    public bool isFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        shakePosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        ogPos = transform.position;
        
        if (timeShake > 0)
        {
            isFinish = false;
            timeShake -= Time.deltaTime;
            shakePosition.x = Random.Range(-shakeMagnitude, shakeMagnitude);
            shakePosition.y = Random.Range(-shakeMagnitude, shakeMagnitude);
            transform.position = transform.position + shakePosition;
        }
        else
        {
            transform.position = transform.parent.position;
            isFinish = true;
        }
    }

    public void CameraShakeSettings(float time, float magnitude)
    {
        timeShake = time;
        shakeMagnitude = magnitude;
    }
}
