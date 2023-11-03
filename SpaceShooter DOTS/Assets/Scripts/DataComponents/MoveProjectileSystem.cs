using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct PlayerProjectileMovementSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var (transform, projectileProperties) in SystemAPI.Query<RefRW<LocalTransform>, ProjectileComponent>())
        {
            transform.ValueRW.Position += transform.ValueRO.Up() * projectileProperties.ProjectileSpeed * deltaTime;
        }
    }
}
