using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlash : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;

    private SpriteRenderer sp;
    private Material originaMaterial;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        originaMaterial = sp.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlashP(float duration)
    {
         IEnumerator FlashRoutine()
        {
                sp.material = flashMaterial;
                yield return new WaitForSeconds(duration);
                sp.material = originaMaterial;
            
        }
        StartCoroutine(FlashRoutine());
    }

}
