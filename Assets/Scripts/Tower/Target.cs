using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Transform bodyTower;
    Transform closerEnemy;


    void Start()
    {
        StartCoroutine(SetCloserEnemy());
    }
    void Update()
    {
        bodyTower.LookAt(closerEnemy);
    }



    IEnumerator SetCloserEnemy()
    {
        yield return new WaitForSeconds(1);
        closerEnemy = FindObjectOfType<EnemyMover>().transform;
    }





}
