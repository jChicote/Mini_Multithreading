using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public int agentCount;
    public Agent[] agents;
    public GameObject agentPrefab;

    // Start is called before the first frame update
    void Start()
    {
        agents = new Agent[agentCount];
        Agent agent;
        for (int i = 0; i < agentCount; i++)
        {
            agent = GameObject.Instantiate(agentPrefab, new Vector3(Random.Range(-2000, 2000), Random.Range(-2000, 2000), -60), Quaternion.identity).GetComponent<Agent>();
            agents[i] = agent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (Agent agent in agents)
        {
            ThreadStart thread = delegate
            {
                agent.MoveAgent();
            };

            thread.Invoke();
        }*/

        foreach (Agent agent in agents)
        {
            agent.MoveAgent();
        }
    }

    public void PerformThroughJobSystem()
    {

    }
}
