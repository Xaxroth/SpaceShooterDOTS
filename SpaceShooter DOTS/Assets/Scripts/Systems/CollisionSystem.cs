using Unity.Entities;
using Unity.Collections;
using Unity.Physics;
using Unity.Mathematics;
using UnityEngine;
using SpaceShooter.DOTS;

[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public partial struct CollisionSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<EndFixedStepSimulationEntityCommandBufferSystem.Singleton>();
    }

    public void OnUpdate(ref SystemState state)
    {
        var buffer = SystemAPI.GetSingleton<EndFixedStepSimulationEntityCommandBufferSystem.Singleton>();
        var EntityCommandBuffer = buffer.CreateCommandBuffer(state.WorldUnmanaged);

        foreach (var projectileAspect in SystemAPI.Query<ProjectileAspect>().WithAll<ProjectileTag>())
        {
            foreach (var asteroidAspect in SystemAPI.Query<AsteroidAspect>().WithAll<AsteroidTag>())
            {
                if (math.distance(projectileAspect.GetPosition.x, asteroidAspect.GetPosition.x) < 0.25f &&
                    math.distance(projectileAspect.GetPosition.y, asteroidAspect.GetPosition.y) < 0.25f)
                {
                    Entity asteroidEntity = asteroidAspect.AsteroidEntity;
                    var newTransform = asteroidAspect.GetRandomTransform();

                    EntityCommandBuffer.SetComponent(asteroidEntity, newTransform);
                    EntityCommandBuffer.DestroyEntity(projectileAspect.ProjectileEntity);
                }
            }
        }

    }
}
