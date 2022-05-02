using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSelector : MonoBehaviour
{
    public static event Action<int, string> agentCheck;
    public static event Action clearAgentSelection;
    [SerializeField] GameObject agentSelectionMark;
    static GameObject clone =  null;
    Vector3 offset = new Vector3(0,.7f,0); // allows marker to be a little bit above agent head

   
    void Update()
    {
        UncheckAgent();
    }

    void OnMouseDown()
    {
        SelectAgent();
    }

    void UncheckAgent()
    {
        if (Input.GetMouseButtonDown(1)) // right click allows to uncheck Agent if it's checked already
        {
            if (clone != null)
            {
                Destroy(clone);
                clearAgentSelection?.Invoke();
            }
        }
    }

    private void SelectAgent()
    {
        if (clone != null)
        {

            Destroy(clone);
        }
        clone = Instantiate(agentSelectionMark, transform.position + offset, Quaternion.identity, gameObject.transform);
        agentCheck?.Invoke(gameObject.GetComponent<AgentHealth>().currentHealthpoints, gameObject.name);
    }
}
