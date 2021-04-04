using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using Unity.Burst;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Entities;
using UnityEngine.Jobs;


[BurstCompile]
public struct MovementUpdateJob : IJobParallelForTransform
{
    [ReadOnly]
    public NativeArray<float> speeds;

    [ReadOnly]
    public float deltaTime;

    public void Execute(int index, TransformAccess transform)
    {
        transform.position += Vector3.forward * speeds[index] * deltaTime;
    }
}

public class Agent : MonoBehaviour
{

}
