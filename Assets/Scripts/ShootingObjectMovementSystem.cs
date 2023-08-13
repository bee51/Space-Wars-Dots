using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;


public partial struct ShootingObjectMovementSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<GameDataAuthoring.GameData>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        
        var deltaTime = SystemAPI.Time.DeltaTime;
        var job = new BulletShootingObjectJob
        {
            DeltaTime = deltaTime
        };
        job.Schedule();
    }
}

public partial struct BulletShootingObjectJob : IJobEntity
{
    public float DeltaTime;
    public void Execute(ref LocalTransform transform , in ShootingObjectAuthoring.MoveObject objectPos)
    {
        transform.Position.x += (objectPos.Velocity*DeltaTime);
    }
}