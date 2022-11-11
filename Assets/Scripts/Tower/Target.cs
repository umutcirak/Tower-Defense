using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Transform bodyTower;
    [SerializeField] float waitTimeTarget;  // time needed to target to new enemy
    [SerializeField] float targetRange;

    Transform closestEnemyPos;
    float enemyDistance = 0f; 

    Enemy[] enemies;
    int activeEnemies = 0;

    ParticleSystem bulletThrower;

    void Awake()
    {
        bulletThrower = GetComponentInChildren<ParticleSystem>();
    }
    void Start()
    {
        StartCoroutine(SetCloserEnemy());
    }

    void Update()
    {        
        AimTower();
        SetTowerAttack();
    }

    IEnumerator SetCloserEnemy()
    {      
        do
        {
            yield return new WaitForSeconds(waitTimeTarget);

            enemies = FindObjectsOfType<Enemy>();      
            float closestDistance = Mathf.Infinity;

            foreach (Enemy enemy in enemies)
            {
                if(!enemy.isActiveAndEnabled) { continue; }
                              
                float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);             
                
                if(enemyDistance < closestDistance)
                {
                    closestDistance = enemyDistance;
                    closestEnemyPos = enemy.transform; 
                }                
            }            

        } while (enemies.Length != 0);

    }

    void AimTower()
    {
        bodyTower.LookAt(closestEnemyPos);
    }

    void SetTowerAttack()
    {
        if(closestEnemyPos == null) { return; }

        enemyDistance = Vector3.Distance(transform.position, closestEnemyPos.position);

        var emissionModule = bulletThrower.emission;

        var emissionRate = emissionModule.rateOverTime;

        if(enemyDistance > targetRange) 
        {
            emissionModule.rateOverTime = emissionRate;
        }
        else
        {
            emissionModule.rateOverTime = 0;
        }        
    }


   


}
