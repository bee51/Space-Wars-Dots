using Unity.Entities;
using UnityEngine;

public class PlayerDataAuthenticator : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public Transform spawnPoint;


     class PlayerSpeedBaker : Baker<PlayerDataAuthenticator>
    {
        
        public override void Bake(PlayerDataAuthenticator authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity,new PlayerData
            {
                PlayerSpeed = authoring.moveSpeed,
                RotationSpeed = authoring.rotateSpeed,
                SpawnPoint= GetEntity(authoring.spawnPoint,TransformUsageFlags.Dynamic)
                
            });
        }
    }
}
