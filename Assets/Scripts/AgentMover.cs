
using System.Collections.Generic;
using UnityEngine;

public class AgentMover : MonoBehaviour
{
    Vector3[] vectors = new Vector3[] {Vector3.forward, Vector3.back, Vector3.left, Vector3.right};
    Vector3 startposition;
    int vectorIndex;
    bool vectorChoosed2 = false;
    bool vectorChoosed4 = false;
    bool vectorChoosed6 = false;
    float distance ;

    void Start()
    {
        startposition = transform.position; //setting initial position so we can check the distance
        ChooseVector();

    }


    void Update()
    {
        distance = Vector3.Distance(startposition, transform.position);
        
        MoveAgent();
        ResetVector();
    }

    void ChooseVector() // choosa random starting vector 
    {
        vectorIndex = Random.Range(0, 4);
    }

    void MoveAgent() //switch Vector if Agent approach a bondary
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

        ChangeDirection();

        transform.Translate(vectors[vectorIndex] * Time.deltaTime);
    }

    void ChangeDirection() // agent is able to to change direction after sme distance
    {
        if (distance > 2)
        {
            if (!vectorChoosed2)
            {
                ChooseVector(); //choose random moving vector while on the move
                vectorChoosed2 = true;
            }
        }
        if (distance > 4)
        {
            if (!vectorChoosed4)
            {
                ChooseVector();
                vectorChoosed4 = true;
            }
        }

        if (distance > 6)
        {
            if (!vectorChoosed6)
            {
                ChooseVector();
                vectorChoosed6 = true;
            }
        }
    }


    void ResetVector() // reset bools so agent can switch direction multiple times;
    {
        if (distance<=6 && distance >=4)
        {
            vectorChoosed6 = false;
        }

        if (distance<=4 && distance >=2)
        {
            vectorChoosed4 = false;
        }

        if (distance<=2)
        {
            vectorChoosed4 = false;
        }
    }

}
