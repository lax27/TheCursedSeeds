using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo : MonoBehaviour
{
    public bool plusVector;
    public bool equalVector;
    public bool minusVector;

    public float X;
    public float Y;
    public float Z;

    public GameObject moveThis;
    public GameObject thistoo;

    public bool urgentFix;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (plusVector)
        {
            moveThis.transform.position += new Vector3(X, Y, Z);
            
            if(thistoo != null)
            {
                thistoo.transform.position += new Vector3(X, Y, Z);

            }
        }
        else if (minusVector)
        {
            moveThis.transform.position -= new Vector3(X, Y, Z);

            if (thistoo != null)
            {
                thistoo.transform.position -= new Vector3(X, Y, Z);

            }
        }
        else if (equalVector)
        {
            moveThis.transform.position = new Vector3(X, Y, Z);

            if(urgentFix)
            {
                StartCoroutine(Fix());
            }

            if (thistoo != null)
            {
                thistoo.transform.position = new Vector3(X, Y, Z);
            }
        }
    }

    IEnumerator Fix()
    {
        float t = 0f;
        while((t+= Time.deltaTime) < 1f)
        {
            yield return null;
            moveThis.transform.position = new Vector3(X, Y, Z); ;
        }
    }
}
