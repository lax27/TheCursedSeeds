using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class button_responsive : MonoBehaviour
{
    public TMP_Text text;
    public int seed_number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.instance.inventory[seed_number].ToString();
        if(GameManager.instance.inventory[seed_number] >= 64)
        {
            GameManager.instance.inventory[seed_number] = 64;
        }
    }

    public void Plant()
    {
        //seed - 1 
        GameManager.instance.inventory[seed_number]--;

        //call function
        //GameManager.instance.GrowingPlant(seed_number);
    }
}
