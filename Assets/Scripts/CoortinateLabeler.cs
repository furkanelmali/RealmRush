using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteAlways]
public class CoortinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int(); 
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();   

    }

    void Update()
    {
        if (!Application.isPlaying) 
        {
            DisplayCoordinates();
            UpdateObjectName(); 
        }
    }

    void DisplayCoordinates() //Showing the objects coordinates
    {
        coordinates.x =Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName() //changing the name of object with the coordinates
    {
        transform.parent.name = label.text;
    
    
    }


}
