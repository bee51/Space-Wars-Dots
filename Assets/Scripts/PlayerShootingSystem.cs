using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[UpdateBefore(typeof(Transform))]
public partial struct PlayerShootingSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<PlayerData>();
        state.RequireForUpdate<GameData>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }
        var config = SystemAPI.GetSingleton<GameData>();
        var playerEntity = SystemAPI.GetSingletonEntity<PlayerData>();
        var playerMoveData =SystemAPI.GetComponentRO<LocalTransform>(playerEntity);

        var entity=state.EntityManager.Instantiate(config.ShootingObjectBullet,1,Allocator.Temp);
        foreach (var item in entity)
        {
            var transform = SystemAPI.GetComponentRW<LocalTransform>(item);
                
            transform.ValueRW.Position = playerMoveData.ValueRO.Position;
        }
    }

}