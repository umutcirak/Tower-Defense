using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Transform bodyTower;
    Transform closerEnemy;


    void Start()
    {
        closerEnemy = FindObjectOfType<EnemyMover>().transform;
    }
    void Update()
    {
        bodyTower.LookAt(closerEnemy);
    }







}
