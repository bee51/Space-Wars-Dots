using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class ShootingObjectAuthoring : MonoBehaviour
{
    public float speed;
    public float damage;
    public float totalTime;

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
                Velocity = authoring.speed,
                Time= authoring.totalTime
            });
        }
    }

    
}
public struct ShootingObject : IComponentData ,IEnableableComponent
{
    public float DamageAmount;
    public float İtemHitAmount;
    public bool IsFired;

}
public struct MoveObject :  IComponentData ,IEnableableComponent
{
    public float3 Velocity;
    public float CurrentTime;
    public float Time;
}
