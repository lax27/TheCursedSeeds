using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyText : MonoBehaviour
{
    public TMP_Text moneyAmountText;
    // Start is called before the first frame update
    void Start()
    {
     
        moneyAmountText = GameObject.Find("MoneyText").GetComponent<TMP_Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = GameManager.instance.money.ToString();
    }
}
