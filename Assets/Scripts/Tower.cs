using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerprize = 50;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool createTower(Tower tower, Vector3 position) 
    {
        MoneySystem moneysystem = FindObjectOfType<MoneySystem>();

        if(moneysystem != null) { 
        if (moneysystem.CurrentGold >= towerprize)
        {  
            Instantiate(tower.gameObject, position, Quaternion.identity);
            moneysystem.extract(towerprize);
            return true;
        }

        }

        return false;
    }
}
