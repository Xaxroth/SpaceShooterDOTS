using SpaceShooter.DOTS;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerProjectileMono : MonoBehaviour
{
    public int Health;
    public bool IsDead;
    public float ProjectileMovementSpeed;
    public GameObject ProjectilePrefab;
    public int ProjectileDamage;

    public class ProjectileBaker : Baker<PlayerProjectileMono>
    {
        public override void Bake(PlayerProjectileMono authoring)
        {
            var projectileEntity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(projectileEntity, new ProjectileComponent()
            {
                ProjectileSpeed = 1,
                ProjectileObject = GetEntity(authoring.ProjectilePrefab, TransformUsageFlags.Dynamic),
            });
            AddComponent(projectileEntity, new FireProjectileTag(){ });
        }
    }
}
