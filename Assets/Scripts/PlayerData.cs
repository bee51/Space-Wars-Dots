using Unity.Entities;

public struct PlayerData : IComponentData
{
    public float PlayerSpeed;
    public float RotationSpeed;
    public Entity SpawnPoint;
}
