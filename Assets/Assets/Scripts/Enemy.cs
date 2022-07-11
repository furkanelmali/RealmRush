using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int reward = 25;
    [SerializeField] int penalty = 25;

    MoneySystem moneysystem;
    // Start is called before the first frame update
    void Start()
    {
        moneysystem = FindObjectOfType<MoneySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rewardGold() 
    {
        if(moneysystem == null)
        { return; }
        else 
        {
            moneysystem.adding(reward); 
        }
        
    }
    public void penaltyGold()
    {
        if (moneysystem == null)
        { return; }
        else
        {
            moneysystem.extract(penalty);
        }
    }
}
