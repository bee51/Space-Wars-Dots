using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;


[UpdateBefore(typeof(EnemyMovementSystem))]
[BurstCompile]
public partial struct EnemySpawnSystem : ISystem
{
    public float timeStart;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<GameData>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var data = SystemAPI.GetSingleton<GameData>().EnemyObject;
        var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
        if (timeStart >= 0)
        {
            timeStart -= SystemAPI.Time.DeltaTime;
            return;
        }

        var job = new EnemySpawnJob
        {
            SpawnEnemy = data,
            ECB = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)
        };
        job.Schedule();
        timeStart = 1f;
    }
}
[BurstCompile]
public partial struct EnemySpawnJob : IJobEntity
{
    public EntityCommandBuffer ECB;
    public Entity SpawnEnemy;

    public void Execute(ref LocalTransform transform, in SpawnPoint point)
    {
        var spawnedEntity = ECB.Instantiate(SpawnEnemy);
       ECB.SetComponent(spawnedEntity,transform);
    }
}