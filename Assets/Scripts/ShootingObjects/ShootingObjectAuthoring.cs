using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ShootingObjects
{
    public class ShootingObjectAuthoring : MonoBehaviour
    {
        class Baker : Baker<ShootingObjectAuthoring>
        {
            public override void Bake(ShootingObjectAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,new Ball ());
                AddComponent(entity,new Velocity());
            }
        }
    }

    public struct Ball : IComponentData
    {
        
    }
    public struct Velocity : IComponentData
    {
        public float2 Value;
    }
}
