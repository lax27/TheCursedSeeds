using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedsCountShop : MonoBehaviour
{
    public TMP_Text seedCount;
    public int idSeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seedCount.text = GameManager.instance.inventory[idSeed].ToString();
    }
}
