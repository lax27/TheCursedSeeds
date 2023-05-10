using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo : MonoBehaviour
{
    public bool PlusVector;
    public bool equalVector;
    public bool minusVector;

    public float X;
    public float Y;
    public float Z;

    public GameObject MoveThis;
    public GameObject Thistoo;

    public bool urgentFix;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlusVector)
        {
            MoveThis.transform.position += new Vector3(X, Y, Z);
            
            if(Thistoo != null)
            {
                Thistoo.transform.position += new Vector3(X, Y, Z);

            }
        }
        else if (minusVector)
        {
            MoveThis.transform.position -= new Vector3(X, Y, Z);

            if (Thistoo != null)
            {
                Thistoo.transform.position -= new Vector3(X, Y, Z);

            }
        }
        else if (equalVector)
        {
            MoveThis.transform.position = new Vector3(X, Y, Z);

            if(urgentFix)
            {
                StartCoroutine(Fix());
            }

            if (Thistoo != null)
            {
                Thistoo.transform.position = new Vector3(X, Y, Z);

            }
        }
    }

    IEnumerator Fix()
    {
        float t = 0f;
        while((t+= Time.deltaTime) < 1f)
        {
            yield return null;
            MoveThis.transform.position = new Vector3(X, Y, Z); ;
        }

    }
}
