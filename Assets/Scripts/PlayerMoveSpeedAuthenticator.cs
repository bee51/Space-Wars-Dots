using Unity.Entities;
using UnityEngine;

public class PlayerMoveSpeedAuthenticator : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

     class PlayerSpeedBaker : Baker<PlayerMoveSpeedAuthenticator>
    {
        
        public override void Bake(PlayerMoveSpeedAuthenticator authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity,new PlayerMoveData
            {
                PlayerSpeed = authoring.moveSpeed,
                RotationSpeed = authoring.rotateSpeed
            });
        }
    }
}
