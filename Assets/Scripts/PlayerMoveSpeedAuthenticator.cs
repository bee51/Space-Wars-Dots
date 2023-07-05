using Unity.Entities;
using UnityEngine;

public class PlayerMoveSpeedAuthenticator : MonoBehaviour
{
    public float moveSpeed;
     class PlayerSpeedBaker : Baker<PlayerMoveSpeedAuthenticator>
    {
        public override void Bake(PlayerMoveSpeedAuthenticator authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity,new PlayerMoveSpeed
            {
                PlayerSpeedData = authoring.moveSpeed
            });
        }
    }
}
