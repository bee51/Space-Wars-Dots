using Unity.Entities;
using UnityEngine;

public class GameDataAuthoring : MonoBehaviour
{
    public GameObject Prefab;

    private class GameDataBaker : Baker<GameDataAuthoring>
    {
        public override void Bake(GameDataAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity,new GameData
            {
                ShootingObjectBullet = GetEntity(authoring.Prefab,TransformUsageFlags.Dynamic)
            });
        }
    }
    
    
    
    
    //it will add game items and values
    public struct GameData: IComponentData
    {
        public Entity ShootingObjectBullet;
    }
}