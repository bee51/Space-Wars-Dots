using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


public partial struct ShootingObjectMovementSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<GameData>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        
        var deltaTime = SystemAPI.Time.DeltaTime;
        var player = SystemAPI.GetComponentRO<LocalTransform>(SystemAPI.GetSingletonEntity<PlayerMoveData>());
        var job = new BulletShootingObjectJob
        {
            DirectionVector = player.ValueRO.Rotation,
            DeltaTime = deltaTime
        };
        job.Schedule();
   
    }
}


public partial struct BulletShootingObjectJob : IJobEntity
{
    public float DeltaTime;

    public quaternion DirectionVector;
    //todo: it will add spawning road

    public void Execute(ref LocalTransform transform , in MoveObject objectPos)
    {
        transform.Rotation = DirectionVector;
        
        transform.Position += (objectPos.Velocity*DeltaTime);
        
        
    }
}
