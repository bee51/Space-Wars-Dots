using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace ShootingObjects
{
    partial struct BallSpawnerSystem : ISystem
    {
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<ConfigData>();
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (SystemAPI.GetSingleton<GameStateData>().Value != GameState.Start)
            {
                return;
                
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
             
                
            }
            
        }
    }
}