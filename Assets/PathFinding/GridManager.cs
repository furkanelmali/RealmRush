using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
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
