using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    

    public void MoveAgent()
    {
        transform.position += transform.forward * Random.Range(3, 10f) * Time.deltaTime ;
    }
}
