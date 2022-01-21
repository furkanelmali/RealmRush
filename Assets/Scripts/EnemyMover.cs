 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] float waittime = 1f;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FollowPath() 
    {
        foreach (WayPoint point in path)
        {
            this.gameObject.transform.position = point.transform.position;

            yield return new WaitForSeconds(waittime);
        }


    }
}
 
