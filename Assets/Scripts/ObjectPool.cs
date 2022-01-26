using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] int poolSize = 5;
    [SerializeField] float timer = 1f;
   

    GameObject[] pool;
    void Awake()
    {
        populatePool();
    }
    void Start()
    {
        StartCoroutine(spawnEnemy());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void populatePool() 
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++) 
        {
            pool[i] = Instantiate(Enemy, transform);
            pool[i].SetActive(false);
        }   
    }
    void EnableObjectInPool() 
    {
        for(int i = 0; i < pool.Length; i++) 
        {
            if (pool[i].activeInHierarchy == false) 
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator spawnEnemy() 
    {
        while (true) 
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(timer);
        }
    
    }
}
 