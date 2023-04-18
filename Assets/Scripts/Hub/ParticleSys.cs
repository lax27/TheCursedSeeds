using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSys : MonoBehaviour
{
    public ParticleSystem Part;
    public GameObject Sys;
    // Start is called before the first frame update
    void Start()
    {
        Part = Sys.GetComponent<ParticleSystem>();
        Part.startColor = new Color(246,255,0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
