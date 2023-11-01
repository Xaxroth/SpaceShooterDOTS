using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Rendering;

public readonly partial struct IndividualAsteroidAspect : IAspect
{
    // The aspect for individual asteroids. Handles their individual behaviors.
    public readonly Entity Entity;
    private readonly RefRW<LocalTransform> transform;
    private readonly RefRO<Asteroid> _asteroid;

    private float Speed => _asteroid.ValueRO.AsteroidSpeed;

    private float3 Position
    {
        get => transform.ValueRO.Position;
        set => transform.ValueRW.Position = value;
    }

    public void Move(float deltaTime)
    {
        var moveDir = (new float3(0, 0, 0) - transform.ValueRO.Position);
        Position += moveDir * Speed * deltaTime;
    }
}
