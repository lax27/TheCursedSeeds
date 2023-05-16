using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlash : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;

    private SpriteRenderer sr;
    private Material originalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalMaterial = sr.material;
    }

    public void FlashP(float duration)
    {
         IEnumerator FlashRoutine()
         {
            sr.material = flashMaterial;
            yield return new WaitForSeconds(duration);
            sr.material = originalMaterial;
         }

        StartCoroutine(FlashRoutine());

    }
}
