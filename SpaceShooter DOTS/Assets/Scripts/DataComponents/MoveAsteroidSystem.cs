using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace SpaceShooter.DOTS
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct MoveAsteroid : ISystem
    {
        public EntityManager EntityManager { get; private set; }
        // Runs when the game starts, sets up the spawn asteroid functionality and prepares it for the asteroid manager
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.Enabled = true;
            state.RequireForUpdate<Asteroid>();
        }

        // Runs automatically.
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;

            new AsteroidMovementJob
            {
                DeltaTime = deltaTime
            }.ScheduleParallel();
        }

        [BurstCompile]
        public partial struct AsteroidMovementJob : IJobEntity
        {
            public float DeltaTime;

            [BurstCompile]
            private void Execute(IndividualAsteroidAspect Asteroid)
            {
                Asteroid.Move(DeltaTime);
            }
        }
    }
}
