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
        var player = SystemAPI.GetComponentRO<LocalTransform>(SystemAPI.GetSingletonEntity<PlayerData>());
        var job = new BulletShootingObjectJob
        {
            DeltaTime = deltaTime,
            PlayerTransform = player.ValueRO
        };
        job.Schedule();
        
    }
}

[BurstCompile]

public partial struct BulletShootingObjectJob : IJobEntity
{
    public float DeltaTime;
    public LocalTransform PlayerTransform;
    //todo: it will add spawning road

    public void Execute(ref LocalTransform transform, in MoveObject objectPos, in ShootingObject shootingObject)
    {
        transform.Rotation = PlayerTransform.Rotation;
        transform.Position += (objectPos.Velocity * DeltaTime*new float3(1,0,1));
    }
}