using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyLeft;
    JPMorgan bank;

    private int previousMoney;

    void Start()
    {
        previousMoney = bank.balance;
        moneyLeft.text = bank.balance.ToString();
    }

    private void Awake()
    {
        bank = FindObjectOfType<JPMorgan>();
    }

    void Update()
    {
        SetMoneyLeft();
    }


    void SetMoneyLeft()
    {
        if(previousMoney == bank.balance) { return; } // if wallet is same don't update

        previousMoney = bank.balance;
        moneyLeft.text = bank.balance.ToString();
        
    }


}
