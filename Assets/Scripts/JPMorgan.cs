using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPMorgan : MonoBehaviour
{
    public int balance = 0;

    JPMorgan instance;
    void Awake()
    {
        Singleton();
    }

    void Singleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void DecreaseMoneyByTower(int towerCost)
    {
        balance -= towerCost;
    }


    public void IncreaseMoneyByEnemy(int enemyValue)
    {
        balance += enemyValue;
    }
}
