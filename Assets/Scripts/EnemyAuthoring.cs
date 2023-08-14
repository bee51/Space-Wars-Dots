using Unity.Entities;
using UnityEngine;

public class EnemyAuthoring : MonoBehaviour
{
    private class EnemyBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Enemy
            {
                LiveState = LivingState.Idle
            });
        }
    }
}

public struct Enemy : IComponentData
{
    public LivingState LiveState;
}

public enum LivingState
{
    Idle,
    Attack,
    Death,
}