using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private static (float, float) startPoint = (0f, 0f); // x,z                                                    

    [Range(10f,50f)][SerializeField] float speed;
    [SerializeField] float yPos = 4.5f;
    [SerializeField] int enemyDamage;

    [SerializeField] Waypoint[] waypoints;       

    void OnEnable()
    {       
        FindPath();
        ReturnFirstWayPoint();
        StartCoroutine(FollowPath());
    }      


    void FindPath()
    {
        GameObject path = GameObject.FindGameObjectWithTag("Path");
        waypoints = path.GetComponentsInChildren<Waypoint>();
        SortWayPoints();
    }

    IEnumerator FollowPath()
    {
       
        foreach (Waypoint waypoint in waypoints)
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

        }
        gameObject.SetActive(false);
        FindObjectOfType<JPMorgan>().DecreaseHealthByEnemy(enemyDamage);
    }

    void ReturnFirstWayPoint()
    {
        Transform start = waypoints[0].transform;
        Vector3 startPos = new Vector3(start.position.x, yPos, start.position.z);
        Debug.Log(waypoints[0].transform.position);
        transform.position = startPos;
       
    }

    void SortWayPoints()
    {
        // Item1: Index, Item2: Distance
        float[] distanceList = new float[waypoints.Length];
        float distance;

        // Calculate all distance of waypoints to start point.
        for (int i = 0; i < waypoints.Length; i++)
        {
            float distanceX = waypoints[i].transform.position.x - startPoint.Item1;
            float distanceZ = waypoints[i].transform.position.z - startPoint.Item2;

            distance = Mathf.Pow(distanceX, 2f) + Mathf.Pow(distanceZ, 2f);

            distanceList[i] = distance;
        }
        
        bubbleSort(distanceList);        

    }


    public void bubbleSort(float[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            for (int j = i + 1; j < list.Length; j++)
            {
                if (list[i] > list[j])
                {
                    float tempDist = list[i];
                    list[i] = list[j];
                    list[j] = tempDist;


                    Waypoint temp = waypoints[i];
                    waypoints[i] = waypoints[j];
                    waypoints[j] = temp;
                }
            }

        }
    }







}
