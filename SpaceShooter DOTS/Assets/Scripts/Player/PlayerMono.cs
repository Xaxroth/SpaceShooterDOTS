using SpaceShooter.DOTS;
using Unity.Entities;
using UnityEngine;

namespace SpaceShooter.DOTS
{
public class PlayerAuthoring : MonoBehaviour
{
    public int Health;
    public bool IsDead;
    public float MovementSpeed;
    public float RotationSpeed = 0.5f;
    public float ProjectileSpeed = 1.0f;
    public GameObject ProjectilePrefab;
}

public class PlayerAuthoringBaker : Baker<PlayerAuthoring>
{
    public override void Bake(PlayerAuthoring authoring)
    {
        var playerEntity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent<PlayerTag>(playerEntity);
        AddComponent<InputComponent>(playerEntity);

        AddComponent(playerEntity, new MovementSpeed
        {
            Value = authoring.MovementSpeed,

        });
        AddComponent(playerEntity, new ProjectileComponent
        {
            AsteroidObject = GetEntity(authoring.ProjectilePrefab, TransformUsageFlags.Dynamic),
            AsteroidSpeed = authoring.ProjectileSpeed
        });
    }
}

}
