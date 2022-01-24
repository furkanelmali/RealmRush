using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour

{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject Tower;

    public bool IsPlaceable { get  { return isPlaceable; } }
     void OnMouseDown()
    {

       if (isPlaceable)
       { 
        Instantiate(Tower, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
        isPlaceable = false;
       }

    }  
}
