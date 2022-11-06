using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;


    void OnParticleCollision(GameObject other)
    {
        health--;
        Debug.Log(health);
    }

    void Update()
    {
        DestroyEnemy();
    }


    void DestroyEnemy()
    {
        if(health > 1) { return; }

        gameObject.SetActive(false);
        Destroy(gameObject);

    }

}
