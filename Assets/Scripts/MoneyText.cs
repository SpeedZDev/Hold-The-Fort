using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyText : MonoBehaviour
{
    TMP_Text Moneytext;
    void Start()
    {
        Moneytext = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Moneytext.text = "Money: " + MoneyManager.instance.Money;
    }
}
