using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.Transforms;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;

namespace SpaceShooter.DOTS
{
    public readonly partial struct AsteroidAspect : IAspect
    {
        public readonly Entity AsteroidEntity;
        private readonly RefRO<Asteroid> _asteroid;
        private readonly RefRW<LocalTransform> _localTransform;
        private readonly RefRW<RandomGenerator> _asteroidRandomSeed;
        private readonly RefRW<SpawnTimer> _spawnTimer;

        private float GetRandomScale(float min) => _asteroidRandomSeed.ValueRW.value.NextFloat(min, 1f);

        public bool ShouldSpawnAsteroid => SpawnTimer <= 0f;
        public Entity AsteroidPrefab => _asteroid.ValueRO.AsteroidObject;

        public int AsteroidsToSpawn => _asteroid.ValueRO.TotalNumberOfAsteroids;
        public float AsteroidSize => _asteroid.ValueRO.AsteroidSize;

        public int AsteroidsPerWave => _asteroid.ValueRO.AsteroidsPerWave;

        public float Speed => _asteroid.ValueRO.AsteroidSpeed;


        public LocalTransform AsteroidTransform => _asteroid.ValueRO.LocalTransform;

        // Randomizes the asteroid's transform
        public LocalTransform GetRandomTransform()
        {
            return new LocalTransform
            {
                Scale = GetRandomScale(AsteroidSize),
                Position = GetRandomPosition()
            };
        }

        public float3 GetRandomPosition()
        {
            float3 RandomPosition = _asteroidRandomSeed.ValueRW.value.NextFloat3(-10.0f, 10.0f);
            return RandomPosition;
        }

        // Time between each Asteroid spawn.
        public float SpawnTimer
        {
            get => _spawnTimer.ValueRO.Value;
            set => _spawnTimer.ValueRW.Value = value;
        }

        // The position of the localtransform, the asteroid in the world space.
        public float3 Position
        {
            get => _localTransform.ValueRO.Position;
            set => _localTransform.ValueRW.Position = value;
        }

        // Moves the Asteroid through the MoveAsteroidSystem, requires a target position like the player, or the middle of the screen.
        public void Move(float DeltaTime, float3 TargetPosition)
        {
            var moveDir = (TargetPosition - _localTransform.ValueRO.Position);
            Position += moveDir * Speed * DeltaTime;
        }
    }
}
