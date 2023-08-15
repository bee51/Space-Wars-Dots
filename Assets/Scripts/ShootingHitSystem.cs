﻿using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateAfter(typeof(ShootingObjectMovementSystem))]
public partial struct ShootingHitSystem : ISystem
{
    EntityCommandBufferSystem entityCommandBufferSystem;

    public  void OnCreate()
    {
        // EntityCommandBufferSystem oluşturma
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        
        foreach (var (enemyTransform, enemy,enemyEntity) in SystemAPI.Query<RefRO<LocalTransform>, RefRW<Enemy>>().WithEntityAccess())
        {
            foreach (var (shootingTransform,shootingObject,entity) in  SystemAPI.Query<RefRO<LocalTransform>,RefRW<ShootingObject>>().WithEntityAccess())
            {
                if (math.distance(enemyTransform.ValueRO.Position,shootingTransform.ValueRO.Position)<1)
                {
                    enemy.ValueRW.LiveState = LivingState.Death;
                    state.EntityManager.SetComponentEnabled<Enemy>(enemyEntity,false);
                    state.EntityManager.SetComponentEnabled<ShootingObject>(entity,false);

                }
            }
        }
        
        

    }
}
[BurstCompile]
[WithDisabled(typeof(MoveObject))]
public partial struct SpawnJob : IJobEntity
{
    public EntityCommandBuffer.ParallelWriter CommandBuffer;

    public void Execute(ref LocalTransform obj , ref Entity item)
    {

    }
}