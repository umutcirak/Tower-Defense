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
        previousMoney = bank.Balance;
        moneyLeft.text = bank.Balance.ToString();
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
        if(previousMoney == bank.Balance) { return; } // if wallet is same don't update

        previousMoney = bank.Balance;
        moneyLeft.text = bank.Balance.ToString();
        
    }


}
