using Unity.Entities;
using UnityEngine;

public class ShootingObjectAuthoring : MonoBehaviour
{
    public float speed;
    public float damage;
    private class ShootingObjectBaker : Baker<ShootingObjectAuthoring>
    {
        
        public override void Bake(ShootingObjectAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new ShootingObject
            {
                DamageAmount = authoring.damage
            });
            AddComponent(entity,new MoveObject
            {
                Velocity = authoring.speed
            });
        }
    }

    
}
public struct ShootingObject : IComponentData
{
    public float DamageAmount;
        
}
public struct MoveObject :  IComponentData
{
    public float Velocity;
}
