using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;


[UpdateBefore(typeof(EnemyMovementSystem))]
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
        var data = SystemAPI.GetSingleton<GameData>();
        if (timeStart >= 0)
        {
            timeStart -= SystemAPI.Time.DeltaTime;
            return;
        }


          foreach (var localTransform in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<SpawnPoint>())
        {
      var spawnedEntity=state.EntityManager.Instantiate(data.EnemyObject);
      var enemyTransform=SystemAPI.GetComponentRW<LocalTransform>(spawnedEntity);
      enemyTransform.ValueRW.Position = localTransform.ValueRO.Position;
        }
        timeStart = 3f;

    }
}
