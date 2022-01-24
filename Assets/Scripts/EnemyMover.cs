 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f, 5f)]float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
       findPath();
       returnStart();
       StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void findPath() 
    {
        path.Clear();
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach (GameObject waypoint in waypoints) 
        {
            path.Add(waypoint.GetComponent<WayPoint>());
        }
    
    }

    void returnStart() 
    {
        transform.position = path[0].transform.position;
    
    }
    IEnumerator FollowPath() 
    {
        foreach (WayPoint point in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = point.transform.position;
            float travelpercent = 0f;
            
            transform.LookAt(endPosition);
            while (travelpercent < 1f)
            {
                travelpercent+=Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelpercent);  
                yield return new WaitForEndOfFrame();
            }
            
        }

        Destroy(gameObject);
    }
}
 
