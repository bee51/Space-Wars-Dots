using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct PlayerMovementSystem : ISystem
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
        
        
      //todo: it will add rotation
        foreach (var playerTransform in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<PlayerData>())
        {
            playerTransform.ValueRW.Position = playerTransform.ValueRO.Position + input;
            playerTransform.ValueRW.Rotation = LaMouse(playerTransform.ValueRO.Position);

        }
    }

    private quaternion LaMouse(Vector3 pos)
    {
        Vector2 direction = Input.mousePosition - pos;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.up);

        return rotation;
    }
    
}



public enum GameState
{
    Open,
    Start,
    LevelUp,
    Finish,
    
}