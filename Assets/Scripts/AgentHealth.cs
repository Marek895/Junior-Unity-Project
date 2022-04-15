using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
    public static event Action agentDespawn;
    public static event Action clearAgentSelection; //allows to clrea the UI when the selected agent dies
    [SerializeField] Material agenttInjuredMaterial;
    [SerializeField] Material agenttBadlyInjuredMaterial;
    [SerializeField] int maxHealthPoints = 3;

    public int currentHealthpoints;

    // Start is called before the first frame update
    void Start()
    {
        currentHealthpoints = maxHealthPoints;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) 
    {

        currentHealthpoints--;

        if(currentHealthpoints <=0)
        {
            if(transform.childCount>4) //Agent Selection Mark is always 5th child of ageng Object , so when is dies with Agent Selection Mark on it, the UI is cleared
            {
                clearAgentSelection?.Invoke();
            }

            AgentDespawn();
        }

        foreach(Transform bodypart in transform)
        {

            if(currentHealthpoints == 2)
            {
                bodypart.GetComponent<MeshRenderer>().material= agenttInjuredMaterial;
            }
            else if (currentHealthpoints ==1)
            {
                bodypart.GetComponent<MeshRenderer>().material= agenttBadlyInjuredMaterial;
            }
            
        }
    }

    void AgentDespawn()
    {
        this.gameObject.SetActive(false);
        agentDespawn?.Invoke();
    }
}
