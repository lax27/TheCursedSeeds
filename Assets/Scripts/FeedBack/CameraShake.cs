using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private GameObject player;
    private GameObject BasicGun;
    private ShootScript shoot;
    public float duration;
    public float magintude;
    public Vector3 originalPositon;
    // Start is called before the first frame update
    void Start()
    {

        BasicGun = GameObject.Find("BasicGun");
        player = GameObject.Find("mantee_v2");
        shoot = BasicGun.GetComponent<ShootScript>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (shoot.shake)
        {
           
            StartCoroutine(Shake(duration,magintude));
           
            StopCoroutine(Shake(duration,magintude));
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        originalPositon = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = originalPositon;
    }

}
