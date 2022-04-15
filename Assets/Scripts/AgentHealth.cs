using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
    public static event Action agentDespawn;
    public static event Action<int, string> updateAgentHP;
    public static event Action clearAgentSelection; //allows to clear the UI when the selected agent dies
    [SerializeField] Material agenttInjuredMaterial;
    [SerializeField] Material agenttBadlyInjuredMaterial;
    [SerializeField] int maxHealthPoints = 3;

    public int currentHealthpoints;

    
    void Start()
    {
        currentHealthpoints = maxHealthPoints;
    }

    void OnTriggerEnter(Collider other) 
    {

        currentHealthpoints--;

        if(transform.childCount>4) //Selected agent can have updated HP on UI when touches another agent
        {
            updateAgentHP?.Invoke(gameObject.GetComponent<AgentHealth>().currentHealthpoints, gameObject.name);
        }
        if(currentHealthpoints <=0)
        {
            if(transform.childCount>4) //Agent Selection Mark is always 5th child of agent Object , so when is dies with Agent Selection Mark on it, the UI is cleared
            {
                clearAgentSelection?.Invoke();
            }

            AgentDespawn();
        }

        foreach(Transform bodypart in transform) // change agent colllor when collides with another
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
