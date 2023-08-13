using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct MovementSystem : ISystem
{
 
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<GameStateData>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var gameState=SystemAPI.GetSingleton<GameStateData>().Value;
        if (gameState != GameState.Start)
        {
            return;
        }
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        var input = new float3(horizontal, 0, vertical) * SystemAPI.Time.DeltaTime * 5;
        
        if (input.Equals(float3.zero))
        {
            return;
        }

        foreach (var playerTransform in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<PlayerMoveData>())
        {
            playerTransform.ValueRW.Position = playerTransform.ValueRO.Position + input;
        }
    }
    
}



public enum GameState
{
    Open,
    Start,
    LevelUp,
    Finish,
    
}