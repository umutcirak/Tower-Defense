using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [Range(10f,50f)][SerializeField] float speed;
    [SerializeField] List<Waypoint> path;

    void Start()
    {
        StartCoroutine(FollowPath());
    }   
    void Update()
    {
        
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {            
            Vector3 waypointPos = waypoint.transform.position;
            
            Vector3 targetPos = new Vector3(waypointPos.x, transform.position.y, waypointPos.z);
            transform.LookAt(targetPos);

            while (transform.position != targetPos)
            {
                transform.LookAt(targetPos);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            /*
             
            Vector3 targetXPos = new Vector3(waypointPos.x, transform.position.y, transform.position.z);
            Vector3 targetZPos = new Vector3(transform.position.x, transform.position.y, waypointPos.z);

            // FIRST GO PATH On X
            while (transform.position.x != targetPos.x)
            {
                transform.LookAt(targetXPos);
                transform.position = Vector3.MoveTowards(transform.position, targetXPos, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            // Then Go Path On Z
            while (transform.position.z != targetPos.z)
            {
                transform.LookAt(targetZPos);
                transform.position = Vector3.MoveTowards(transform.position, targetZPos, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            */



            // transform.position = new Vector3(waypointPos.x, transform.position.y, waypointPos.z);

        }
    }

  
       
        
    
}
