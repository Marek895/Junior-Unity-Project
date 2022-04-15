using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static event Action agentSpawn;
    [SerializeField] GameObject prefab; // Agent to instantiate
    [SerializeField] [Range(2f, 10f)] float spawnTimer;
    [SerializeField] [Range(1, 30)] int poolsize;
    GameObject[] pool;

    void Awake() 
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnAgent());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolsize];
        string[] names = new string[] {"Joey", "Chandler" , "Monica" , "Phoebie", "Ross" ,"Bob", "John", "Adam", "Paul", "Lara", "Carmen",
         "David", "Armold", "Sophia", "Emily", "Mary","Linda", "Margaret", "Tracy", "Hannah","Sandy", "Sarah", "Richard", "Michael", 
         "Justin", "William", "Connor", "Liam", "Ethan", "Peter" };
        
        for (int i = 0; i<poolsize; i++)
        {

            Vector3 coorditanes = new Vector3(UnityEngine.Random.Range(0f, 10f), .3f, UnityEngine.Random.Range(0f, 10f) );
            pool[i] = Instantiate(prefab,coorditanes,Quaternion.identity, this.transform );
            pool[i].SetActive(false);
            pool[i].name = names[i];
        }

    }

    IEnumerator SpawnAgent()
    {
        foreach (GameObject agent in pool)
        {
            if(agent.activeInHierarchy == false)
            {
                agent.SetActive(true);
                agentSpawn?.Invoke();
                yield return new WaitForSeconds(spawnTimer);
            }
        }
    } 
}
