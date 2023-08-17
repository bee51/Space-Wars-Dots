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
            float4 returnValue = SendRay().value;
            playerTransform.ValueRW.Rotation.value = returnValue;

        }
    }

    public quaternion SendRay()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit))
        {
        }

        return quaternion.LookRotation(hit.point, new float3(0, 1, 0));
        

    }

 
    
}


public enum GameState
{
    Open,
    Start,
    LevelUp,
    Finish,
    
}