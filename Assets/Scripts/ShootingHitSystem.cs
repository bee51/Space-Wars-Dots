using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateAfter(typeof(LateSimulationSystemGroup))]
public partial struct ShootingHitSystem : ISystem
{
    
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();

        var querry = SystemAPI.QueryBuilder().WithAll<LocalTransform>().WithAll<ShootingObject>().Build();
        var myJob = new HitJob
        {
            
            ECB = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged),
            ShooterTransforms = querry.ToComponentDataArray<LocalTransform>(Allocator.Persistent),

        };
        myJob.Schedule();


    }
}

[BurstCompile]
public partial struct HitJob : IJobEntity
{
    public EntityCommandBuffer ECB;
    public NativeArray<LocalTransform> ShooterTransforms;
    public void Execute(ref Enemy enemy, in LocalTransform transform ,Entity entity)
    {
            
        foreach (var shooter in ShooterTransforms )
        {
            if (math.distance(transform.Position,shooter.Position)<.6f)
            {
                enemy.LiveState = LivingState.Death;
                
                ECB.DestroyEntity(entity);

            }
        }
    }
} 
