using Unity.Entities;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameStateAuthenticator : MonoBehaviour
{
    public GameState gameStateData;
    public class GameStateBaker: Baker<GameStateAuthenticator>
    {
        
        public override void Bake(GameStateAuthenticator authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity,new GameStateData
            {
                Value = authoring.gameStateData
            });
        }
    }
}