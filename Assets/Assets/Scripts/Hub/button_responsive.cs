using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class button_responsive : MonoBehaviour
{
    public TMP_Text numberOfSeeds;
    public int seed_number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfSeeds.text = GameManager.instance.inventory[seed_number].ToString();

        if(GameManager.instance.inventory[seed_number] >= 64)
        {
            GameManager.instance.inventory[seed_number] = 64;
        }
    }

    public void Plant()
    {
        if (GameManager.instance.isPlanted == false)
        {
            //seed - 1 
            if (GameManager.instance.inventory[seed_number] <= 0)
            {
                GameManager.instance.inventory[seed_number] = 0;
            }
            else if (GameManager.instance.inventory[seed_number] == 0)
            {
                Debug.Log("not enought seed");
            }
            else if(GameManager.instance.inventory[seed_number] > 0)
            {
                GameManager.instance.inventory[seed_number]--;
                GameManager.instance.GrowingPlant(seed_number);

            }
            //call function
        }
 
    }
}
