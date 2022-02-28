using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Vector2Int startcoordinates;
    [SerializeField] Vector2Int destinationcoordinates;

    Node startNode;
    Node destinationNode;
    [SerializeField] Node currentSearch;

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;

    Queue<Node> frontier = new Queue<Node>();
    

    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

     void Awake()
    {
        gridManager = FindObjectOfType<GridManager>(); 
        if(gridManager != null) 
        {
            grid = gridManager.Grid;
        }

        
    }
    void Start()
    {
        startNode = gridManager.Grid[startcoordinates];
        destinationNode = gridManager.Grid[destinationcoordinates];
        BreadthFirstSearch();
        buildPath();
    }

    void ExploreNeighbors() 
    {
        List<Node> neighbors = new List<Node>();    
        foreach(Vector2Int direction in directions) 
        {
            Vector2Int neighborcoords = currentSearch.coordinates + direction;

            if (grid.ContainsKey(neighborcoords)) 
            {
                neighbors.Add(grid[neighborcoords]);
                
            }
        }

        foreach(Node neighbor in neighbors) 
        {
            if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable) 
            {
                neighbor.connectedTo = currentSearch;
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }
     

    void BreadthFirstSearch() 
    {
        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startcoordinates, startNode);

        while(frontier.Count > 0 && isRunning) 
        {
            currentSearch = frontier.Dequeue();
            currentSearch.isExplored = true;
            ExploreNeighbors();
            if(currentSearch.coordinates == destinationcoordinates) 
            {
                isRunning = false;
            }
        }

        
    
    }
    List<Node> buildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;

        path.Add(currentNode);
        currentNode.isPath = true;
        while(currentNode.connectedTo != null) 
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        
        }

        path.Reverse();
        return path;

    }


}
