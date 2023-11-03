using SpaceShooter.DOTS;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct FireProjectileSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var EntityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
        foreach (var (projectilePrefab, transform) in SystemAPI.Query<ProjectileComponent, LocalTransform>().WithAll<FireProjectileTag>())
        {
            var Projectile = EntityCommandBuffer.Instantiate(projectilePrefab.ProjectileObject);
            var ProjectileTransform = LocalTransform.FromPositionRotationScale(transform.Position, transform.Rotation, 0.5f);
            EntityCommandBuffer.SetComponent(Projectile, ProjectileTransform);

        }
        EntityCommandBuffer.Playback(state.EntityManager);
        EntityCommandBuffer.Dispose();
    }
}
