using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI agentCounterTXT;
    [SerializeField] TextMeshProUGUI agentInfoTXT;
    

    int agentCounter= 0;
    void OnEnable() 
         
    {
        ObjectPool.agentSpawn += IncreaseAgentCounter;
        AgentHealth.agentDespawn += DecreaseAgentCounter;
        AgentHealth.clearAgentSelection += ClearAgentInfo;
        AgentHealth.updateAgentHP += DisplayAgentInfo;
        AgentSelector.agentCheck += DisplayAgentInfo;
        AgentSelector.clearAgentSelection += ClearAgentInfo;
        
    }

    void OnDisable()
    {
        ObjectPool.agentSpawn -= IncreaseAgentCounter;
        AgentHealth.agentDespawn -= DecreaseAgentCounter;
        AgentHealth.clearAgentSelection -= ClearAgentInfo;
        AgentHealth.clearAgentSelection -= ClearAgentInfo;
        AgentSelector.agentCheck -= DisplayAgentInfo;
        AgentSelector.clearAgentSelection -= ClearAgentInfo;
        

    }
    
    void IncreaseAgentCounter()
    {
        agentCounter++;
        agentCounterTXT.text = "Current number of agents " + agentCounter.ToString();
    }

    void DecreaseAgentCounter()
    {
        agentCounter--;
        agentCounterTXT.text = "Current number of agents " + agentCounter.ToString();
    }

    void DisplayAgentInfo(int HP, string name)
    {
        agentInfoTXT.text = "Agent: " +  name + ", ilość HP: " + HP.ToString();
    }


    void ClearAgentInfo()
    {
        agentInfoTXT.text = null;
    }

}
