using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

public class GameDataAuthoring : MonoBehaviour
{
    public GameObject shootBulletPrefab;
    public GameObject enemyPrefab;

    private class GameDataBaker : Baker<GameDataAuthoring>
    {
        public override void Bake(GameDataAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity,new GameData
            {
                ShootingObjectBullet = GetEntity(authoring.shootBulletPrefab,TransformUsageFlags.Dynamic)
                ,
                EnemyObject = GetEntity(authoring.enemyPrefab,TransformUsageFlags.Dynamic)
            });
        }
    }
    
    
    
 
}
   
//it will add game items and values
public struct GameData: IComponentData
{
    public Entity ShootingObjectBullet;
    public Entity EnemyObject;

}