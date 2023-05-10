using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shells : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float timer = 0.5f;
    [SerializeField] private float timerD = 0.6f;
    private Vector2 dir;
    private PlayerAimWeapon rp;
    private GameObject gunRotation;
    private SpriteRenderer sp;
    private AudioSource audioSource;
    private float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        gunRotation = GameObject.Find("RotatePoint");
        rp = gunRotation.GetComponent<PlayerAimWeapon>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        dir = new Vector2(Random.Range(-6,6),0); //funciona mal,Objetivo Hacer que dispare hacia el lado contrario al que se apunta
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerD -= Time.deltaTime;

        if (timer <= 0.35f)
        {
            sp.sortingLayerName = "ice cube";
            rb.gravityScale = 100;
        }
        if (timer <= 0)
        {
            sp.sortingLayerName = "details";
            rb.bodyType = RigidbodyType2D.Static;
            if(audioSource != null)
                audioSource.Play();
            StartCoroutine(DestroySound());
        }
            Destroy(gameObject, 100f);
    }

    private void FixedUpdate()
    {
        rb.AddForce(dir ,ForceMode2D.Impulse);
    }

    private IEnumerator DestroySound()
    {
        Destroy(audioSource);
        yield return new WaitForSecondsRealtime(time);
    }

}
