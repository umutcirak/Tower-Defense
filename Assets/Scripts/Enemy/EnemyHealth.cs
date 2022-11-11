using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] int enemyValue;


    JPMorgan bank;

    private void Awake()
    {
        bank = FindObjectOfType<JPMorgan>();
    }

    void OnParticleCollision(GameObject other)
    {
        health--;
        Debug.Log(health);
    }

    void Update()
    {
        DeaActivateEnemy();
    }


    void DeaActivateEnemy()
    {
        if(health > 1) { return; }

        gameObject.SetActive(false);

        bank.IncreaseMoneyByEnemy(enemyValue);

    }

}
