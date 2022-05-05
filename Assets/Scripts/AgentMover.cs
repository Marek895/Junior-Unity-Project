using System.Collections.Generic;
using UnityEngine;

public class AgentMover : MonoBehaviour
{
    [SerializeField] float agentSpeed = 2f;
    [SerializeField] float movementDuration = 5f;
    Vector3[] vectors = new Vector3[] {Vector3.forward, Vector3.back, Vector3.left, Vector3.right};
    Vector3 startposition;
    int vectorIndex;
    float distance ;
    float currentTime;
    

    void Start()
    {
        startposition = transform.position; //setting initial position so we can check the distance
        currentTime = Time.time;
        ChooseVector(); // choosa random starting vector 
    }

    void Update()
    {
        ControlAgent();
    }

    void ChooseVector() 
    {
        int currentVectorIndex = vectorIndex;
        while (currentVectorIndex == vectorIndex)
        {
            vectorIndex = Random.Range(0, 4);
        }
        
    }

    void ControlAgent()
    {
        AvoidBondary(); //switch Vector if Agent approach a bondary
        ChangeDirection(); // agent is able to change direction after some time
        MoveAgent();
    }

    private void AvoidBondary() 
    {
        if (transform.position.x >= 10)
        {
            vectorIndex = 2;
        }
        if (transform.position.x <= 0)
        {
            vectorIndex = 3;
        }
        if (transform.position.z >= 10)
        {
            vectorIndex = 1;
        }
        if (transform.position.z <= 0)
        {
            vectorIndex = 0;
        }
    }

    void ChangeDirection() 
    {
        if (Time.time > currentTime + movementDuration)
        {
            ChooseVector();
            currentTime = Time.time;
        }
    }

    private void MoveAgent()
    {
        transform.Translate(vectors[vectorIndex] * Time.deltaTime * agentSpeed);
    }
}
