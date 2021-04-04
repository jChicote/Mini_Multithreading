using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Jobs;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Entities;

public class AgentSpawner : MonoBehaviour
{
    public int agentCount;
    public Agent[] agents;
    public GameObject agentPrefab;

    [SerializeField] private Mesh agentMesh;
    [SerializeField] private Material agentMaterial;

    TransformAccessArray transformAccessArray;
    JobHandle jobHandle;
    NativeList<float> speeds;

    // Start is called before the first frame update
    void Start()
    {
        AgentStart();

        agents = new Agent[agentCount];
        Agent agent;
        for (int i = 0; i < agentCount; i++)
        {
            agent = GameObject.Instantiate(agentPrefab, new Vector3(Random.Range(-2000, 2000), Random.Range(-2000, 2000), -60), Quaternion.identity).GetComponent<Agent>();
            transformAccessArray.Add(agent.transform);
            speeds.Add(UnityEngine.Random.Range(3f, 25f));
            agents[i] = agent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PerformJobTwo();
    }

    public void PerformJobTwo()
    {
        jobHandle.Complete();

        if(jobHandle.IsCompleted)
        {
            var movementJob = new MovementUpdateJob()
            {
                deltaTime = Time.deltaTime,
                speeds = speeds
            };

            jobHandle = movementJob.Schedule(transformAccessArray);
            JobHandle.ScheduleBatchedJobs();
        }
    }

    public void AgentStart()
    {
        transformAccessArray = new TransformAccessArray(0, -1);
        speeds = new NativeList<float>(1, Allocator.TempJob);
    }

    /*
    public void SpawnObject()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype archetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(Rotation),
            typeof(RenderMesh),
            typeof(RenderBounds),
            typeof(LocalToWorld));

        Entity entity = entityManager.CreateEntity(archetype);
        entityManager.AddComponentData(entity, new Translation { Value = new Unity.Mathematics.float3(-3f, 0.5f, 5f) });
        entityManager.AddSharedComponentData(entity, new RenderMesh
        {
            mesh = agentMesh,
            material = agentMaterial
        });
    }*/
}
