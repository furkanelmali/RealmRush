using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [Tooltip("WorldGridSize - Unity Editor Snap Settings ile eþlenir.")]
    [SerializeField] int worldgridSize = 10;
    public int unityGridSize { get { return unityGridSize; } }
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid  { get { return grid; } }

     void Awake()
    {
        createGrid();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }

        return null;

    }

    public void blockNode(Vector2Int coordinates) 
    {
        if (grid.ContainsKey(coordinates)) 
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position) 
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / unityGridSize);

        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates) 
    {
         Vector3 position = new Vector3Int();
         position.x = coordinates.x * unityGridSize;
         position.z = coordinates.y * (unityGridSize);

        return position;
    }

    void createGrid() 
    {
         for(int i = 0 ; i < gridSize.x; i++) 
         {
            for (int x = 0; x < gridSize.y; i++)
            {
                Vector2Int coordinates = new Vector2Int(i,x);
                grid.Add(coordinates, new Node(coordinates, true));
            }
        }
    }

  
}
