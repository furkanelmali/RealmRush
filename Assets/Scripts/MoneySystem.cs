using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] int startingGold = 150;
    [SerializeField] int currentGold;

    public int CurrentGold { get { return currentGold; } }

     void Awake()
    {
        currentGold = startingGold;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void adding(int amount) 
    {
        currentGold += Mathf.Abs(amount);
    }

    public void extract(int amount)
    {
        currentGold -= Mathf.Abs(amount);
    }
}
