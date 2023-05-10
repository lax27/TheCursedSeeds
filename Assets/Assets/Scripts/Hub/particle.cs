using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{

    public ParticleSystem part_s;
    ParticleSystem.Particle[] parts;
    public GameObject wepon;
    public List<ParticleCollisionEvent> collisionEvents;

    // Start is called before the first frame update
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();

    }

    // Update is called once per frame
    void Update()
    {
        int numParticlesAlive = part_s.GetParticles(parts);

    }

    private void LateUpdate()
    {
        InitializeIfNeeded();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle hit!");


            wepon.transform.position = parts[0].position;
            wepon.SetActive(true);
          Debug.Log(parts[0].position);
    }

    private void OnParticleTrigger()
    {
        Debug.Log("Particle hit!");


        wepon.transform.position = new Vector3(parts[0].position.x, -4.5f, parts[0].position.z);
        wepon.SetActive(true);
        Debug.Log(parts[0].position);
    }

    void InitializeIfNeeded()
    {
        if (part_s == null)
            part_s = GetComponent<ParticleSystem>();

        if (parts == null || parts.Length < part_s.main.maxParticles)
            parts = new ParticleSystem.Particle[part_s.main.maxParticles];
    }
}
