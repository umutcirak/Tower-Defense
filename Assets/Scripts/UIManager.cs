using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyLeft;
    [SerializeField] TextMeshProUGUI healthLeft;
    
    JPMorgan bank;

    private int previousMoney;
    private int previousHealth;

    private void Awake()
    {
        bank = FindObjectOfType<JPMorgan>();
    }

    void Start()
    {
        previousMoney = bank.Balance;
        moneyLeft.text = bank.Balance.ToString();
    }   

    void Update()
    {
        SetMoneyLeft();
        SetHealthLeft();
    }


    void SetMoneyLeft()
    {
        if(previousMoney == bank.Balance) { return; } // if wallet is same don't update

        previousMoney = bank.Balance;
        moneyLeft.text = bank.Balance.ToString();
        
    }

    void SetHealthLeft()
    {
        if (previousHealth == bank.Health) { return; } // if wallet is same don't update

        previousHealth = bank.Health;
        healthLeft.text = bank.Health.ToString();

    }


}
