using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using Unity.Transforms;
using Unity.VisualScripting;

namespace SpaceShooter.DOTS
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnAsteroid : ISystem
    {
        public EntityManager EntityManager { get; private set; }

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.Enabled = true;
            state.RequireForUpdate<Asteroid>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;

            var AsteroidEntity = SystemAPI.GetSingletonEntity<Asteroid>();
            var Asteroid = SystemAPI.GetAspect<AsteroidAspect>(AsteroidEntity);
            int AmountOfEntitiesSpawned = 0;
            var EntityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);

            for (int i = 0; i < Asteroid.AsteroidsToSpawn; i++)
            {
                Entity asteroidEntity = EntityCommandBuffer.Instantiate(Asteroid.AsteroidPrefab);

                AmountOfEntitiesSpawned++;
                var newTransform = Asteroid.GetRandomTransform();

                EntityCommandBuffer.SetComponent(asteroidEntity, newTransform);
            }

            EntityCommandBuffer.Playback(state.EntityManager);
            EntityCommandBuffer.Dispose();

        }
    }
}
