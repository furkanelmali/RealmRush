using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 30f;
    [SerializeField] ParticleSystem projectTileSystem; 
    Transform target;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update() 
    {
        FindCloseTarget();
        AimWeapon();
    }

    
    void FindCloseTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDist = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDist <= range)
            { attack(true); }
            else if ( targetDist > range)
            { attack(false); }

            if (targetDist < maxDistance)
            {
                closestarget = enemy.transform;
                maxDistance = targetDist;
                
              
            }

        }
        target = closestarget;
    }
    public void AimWeapon()
    {
        float targetdist = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);   
    }

    void attack(bool isRange) 
    {
        var emmisionModule = projectTileSystem.emission;
        emmisionModule.enabled = isRange;       
    }
}
