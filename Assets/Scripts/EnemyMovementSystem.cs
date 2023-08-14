using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Jobs;


[UpdateBefore(typeof(TransformSystemGroup))]
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
        var job = new EnemyMoveJob
        {
            enemyPos = pos,
            deltaTime=deltaTime
        };
        job.ScheduleParallel();
    }

}

public partial struct EnemyMoveJob : IJobEntity
{
    public float3 enemyPos;
    public float deltaTime;
    public void Execute(ref LocalTransform transform, in Enemy enemy)
    {
        var divideAmount = transform.Position - enemyPos;
        divideAmount=math.normalize(divideAmount);
        transform.Position -= divideAmount*deltaTime;
    }
}