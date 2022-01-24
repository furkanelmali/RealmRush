using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] float timer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnEnemy() 
    {
        while (true) 
        {
            Instantiate(Enemy,transform);
            yield return new WaitForSeconds(timer);
        }
    
    }
}
 