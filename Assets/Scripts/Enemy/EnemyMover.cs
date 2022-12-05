using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private static (float, float) startPoint = (0f, 0f); // x,z                                                    

    [Range(10f,50f)][SerializeField] float speed;
    [SerializeField] float yPos = 4.5f;
    [SerializeField] int enemyDamage;

    List<Node> path = new List<Node>();

    GridManager gridManager;
    Pathfinder pathFinder;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<Pathfinder>();
    }

    void OnEnable()
    {      
        StartCoroutine(FollowPath());
    }      


    void FindPath()
    {
        path.Clear();
        path = pathFinder.GetPath();        
    }

    IEnumerator FollowPath()
    {
        yield return new WaitForSeconds(1f);
        FindPath();
        ReturnFirstWayPoint();

        foreach (Node node in path)
        {

            Vector3 waypointPos = gridManager.GridPosToWorldPos(node.position);
            
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
        Vector3 startPos = gridManager.GridPosToWorldPos(path[0].position);
        transform.position = startPos;        
    }



}
