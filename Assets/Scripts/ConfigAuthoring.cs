using Unity.Entities;
using UnityEngine;


public class ConfigAuthoring : MonoBehaviour
{
    public GameObject bulletPrefab;
    class BakerConfig: Baker<ConfigAuthoring>
    {
        public override void Bake(ConfigAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
     
            AddComponent(entity,new ConfigData()
            {
                
            });
        }
    } 
}
public struct ConfigData : IComponentData
{
    
    public float BulletSpeed;
    
}