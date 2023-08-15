using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Jobs;


[UpdateBefore(typeof(TransformSystemGroup))]
[UpdateAfter(typeof(EnemySpawnSystem))]
public partial struct EnemyMovementSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<PlayerMoveData>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        Entity entity=SystemAPI.GetSingletonEntity<PlayerMoveData>();
        float3 pos = SystemAPI.GetComponent<LocalTransform>(entity).Position;
        float deltaTime = SystemAPI.Time.DeltaTime;
        EntityQuery shootQuery = SystemAPI.QueryBuilder().WithAll<LocalTransform,ShootingObject>().Build();
        
        var job = new EnemyMoveJob
        {
            ShooterTransforms = shootQuery.ToComponentDataArray<LocalTransform>(state.WorldUpdateAllocator),
            PlayerPos = pos,
            DeltaTime=deltaTime,
   
            
        };
        
        job.ScheduleParallel();
        
    }

}



[StructLayout(LayoutKind.Auto)]
public partial struct EnemyMoveJob : IJobEntity
{
    public float3 PlayerPos;
    public float DeltaTime;
    public NativeArray<LocalTransform> ShooterTransforms;

    public void Execute(ref LocalTransform transform, ref Enemy enemy)
    {
        if (enemy.LiveState == LivingState.Death)
        {
            return;
        }
        var divideAmount = transform.Position - PlayerPos;
        divideAmount=math.normalize(divideAmount);
        transform.Position -= divideAmount*DeltaTime;
        int a = 0;
     
    }
}