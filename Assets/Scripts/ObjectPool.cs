using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] [Range(1f,10f)] float waitTime;
    
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] int poolSize;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }
       
    void Start()
    {
        StartCoroutine(CloneEnemy());
        
    }
    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = SetupEnemy();
        }
    }

    GameObject SetupEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(false);
        newEnemy.transform.parent = transform;
        return newEnemy;
    }

    

    

    IEnumerator CloneEnemy()
    {
        int counter = 0;
        while(true)
        {
            pool[counter].SetActive(true);            
            counter++;
            
            if(counter == poolSize - 1) { counter = 0; }

            yield return new WaitForSeconds(waitTime);
        }        
    }






}
