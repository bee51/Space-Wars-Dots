using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SpawnPointAuthoring : MonoBehaviour
{
    private class SpawnPointBaker : Baker<SpawnPointAuthoring>
    {
        public override void Bake(SpawnPointAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity,new SpawnPoint
            {
                position = authoring.transform.position
            });
            
        }
    }
}
public struct SpawnPoint : IComponentData
{
    public float3 position;
}