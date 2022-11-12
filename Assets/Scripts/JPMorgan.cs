using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPMorgan : MonoBehaviour
{

    [SerializeField] private int balance;
    public int Balance { get { return balance; } }

    [SerializeField] private int health;
    public int Health { get { return health; } }

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


    public void DecreaseBalanceByTower(int towerCost)
    {
        balance -= Mathf.Abs(towerCost);
    }


    public void IncreaseBalanceByEnemy(int enemyValue)
    {
        balance += Mathf.Abs(enemyValue);
    }

    public void IncreaseBalanceByHit(int hitReward)
    {
        balance += Mathf.Abs(hitReward);
    }

    public void DecreaseHealthByEnemy(int enemyDamage)
    {
        health -= Mathf.Abs(enemyDamage);
    }
}
