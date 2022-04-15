using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI agentCounterTXT;

    int agentCounter= 0;
    void OnEnable() 
         
    {
        ObjectPool.agentSpawn += IncreaseAgentCounter;
    }

    void OnDisable()
    {
        ObjectPool.agentSpawn -= IncreaseAgentCounter;
    }
    
    void IncreaseAgentCounter()
    {
        agentCounter++;
        agentCounterTXT.text = "Current number of agents " + agentCounter.ToString();
    }

}
