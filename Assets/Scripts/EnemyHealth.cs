 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    public int currentHitPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maxHitPoint;
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
        { Destroy(this.gameObject); }
        


    }
}
