using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoortinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.white;
    [SerializeField] Color pathColor = new Color(1f, 0.5f,0f);



    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
       gridManager = FindObjectOfType<GridManager>();
        DisplayCoordinates();   
        label.enabled = false;

    }

   
    void Update()
    {
        if (!Application.isPlaying) 
        {
            DisplayCoordinates();
            UpdateObjectName(); 
        }

        SetColorcoordinates();
        toggleLabels();
    }

    void SetColorcoordinates() 
    {
        if(gridManager == null) 
        {
            return;
        }


        Node node = gridManager.GetNode(coordinates);

        if(node == null) 
        {
            return; 
        }

        if (!node.isWalkable) 
        { label.color = blockedColor; }
        else if (node.isPath) 
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else { label.color = defaultColor; }
    }

    void toggleLabels() 
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            label.enabled = !label.IsActive();
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
