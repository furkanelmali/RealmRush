 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField] [Range(0f, 5f)]float speed = 5f;

    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
       findPath();
       returnStart();
       StartCoroutine(FollowPath());
    }

    void Start()
    {
      enemy = GetComponent<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void findPath() 
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform) 
        {
            Tile waypoint = child.GetComponent<Tile>();

            if (waypoint != null) 
            {
                path.Add(waypoint);
            }
        }
    
    }

    void returnStart() 
    {
        transform.position = path[0].transform.position;
    
    }

    void FinishPath() 
    {
        enemy.penaltyGold();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath() 
    {
        foreach (Tile point in path)
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

        FinishPath();

    }
}
 
