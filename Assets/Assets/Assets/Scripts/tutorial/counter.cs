using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class counter : MonoBehaviour
{
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText;
    public float count = 3f;
    public GameObject wea;
    public int counts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wea == null)
        {
            count -= Time.deltaTime;

            if (count <= 0 && counts != 1)
            {
                counts++;
                DialoguePanel.SetActive(false);
            }

            if(count < -1f)
            {

            }
        }
    }
}
