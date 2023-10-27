using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Burst;
using UnityEngine;

namespace SpaceShooter.DOTS
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnAsteroid : ISystem
    {
        // Runs when the game starts, sets up the spawn asteroid functionality and prepares it for the asteroid manager
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.Enabled = true;
            // Makes the OnUpdate function require asteroid data to be assigned in order to run.
            state.RequireForUpdate<Asteroid>();
        }

        // OnDestroy Function, what happens when this instance stops running
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }

        // Runs automatically 
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;
            var AsteroidEntity = SystemAPI.GetSingletonEntity<Asteroid>();
            var Asteroid = SystemAPI.GetAspect<AsteroidAspect>(AsteroidEntity);

            var EntityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);

            for (int i = 0; i < Asteroid.AsteroidsToSpawn; i++)
            {
                EntityCommandBuffer.Instantiate(Asteroid.AsteroidPrefab);
            }

            EntityCommandBuffer.Playback(state.EntityManager);
        }
    }
}
