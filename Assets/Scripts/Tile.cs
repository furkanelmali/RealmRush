using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour

{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower towerPrefab;

    GridManager gridManager;

   
    public bool IsPlaceable { get  { return isPlaceable; } }

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }
    void Start()
    {
       
    }
    void OnMouseDown()
    {

       if (isPlaceable)
       {
        bool isPlaced = towerPrefab.createTower(towerPrefab, transform.position);
        isPlaceable = !isPlaced;
       }

    }  
}
