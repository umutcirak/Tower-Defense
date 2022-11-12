using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{        
   
    [SerializeField] float health;
    [SerializeField] int enemyValue;
    [SerializeField] int rewardPerHit;


    JPMorgan bank;
    private void Awake()
    {
        bank = FindObjectOfType<JPMorgan>();
        
    }

    void OnParticleCollision(GameObject other)
    {

        TakeHit();
    }

    void Update()
    {
        DeaActivateEnemy();
    }


    void DeaActivateEnemy()
    {
        if(health > 1) { return; }

        gameObject.SetActive(false);

        bank.IncreaseBalanceByEnemy(enemyValue);

    }

    void TakeHit()
    {
        health--;
        bank.IncreaseBalanceByHit(rewardPerHit);
    }

}
