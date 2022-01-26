 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    public int currentHitPoints = 0;

    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoint;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnParticleCollision(GameObject other)
    {
       
        processhit();
       
    }
    void processhit() 
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            enemy.rewardGold();
            gameObject.SetActive(false); 
        }
        


    }
}
