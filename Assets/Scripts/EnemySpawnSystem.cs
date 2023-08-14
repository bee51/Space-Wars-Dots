using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[StructLayout(LayoutKind.Auto)]
public partial struct EnemySpawnSystem : ISystem
{
    public float timeStart;
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<GameData>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var data = SystemAPI.GetSingleton<GameData>();
        if (timeStart>=0)
        {
            timeStart -= SystemAPI.Time.DeltaTime;
            return;
        }
        Debug.Log("it is spawned");
        foreach (var localTransform in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<SpawnPoint>())
        {
            var spawnedEntity=state.EntityManager.Instantiate(data.EnemyObject);
            var enemyTransform=SystemAPI.GetComponentRW<LocalTransform>(spawnedEntity);
            enemyTransform.ValueRW.Position = localTransform.ValueRO.Position;
        }
        timeStart = 3f;
    
        
    }
    
}

