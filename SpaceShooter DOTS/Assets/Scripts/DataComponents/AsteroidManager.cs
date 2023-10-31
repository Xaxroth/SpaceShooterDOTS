using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using System;
using UnityEditor.Build.Pipeline.Interfaces;
using Unity.Transforms;
using Unity.Entities.UniversalDelegates;

namespace SpaceShooter.DOTS
{
    public class AsteroidManager : MonoBehaviour
    {
        public int AmountOfAsteroids;
        public int AsteroidsToSpawn;
        public uint RandomSeed;
        public GameObject[] SpawnableAsteroids;

        // VERY IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public GameObject AsteroidPrefab;
        // VERY IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Entity AsteroidEntity;

        public int AsteroidMaxHealth = 100;
        public int AsteroidMinHealth = 1;

        public float AsteroidMaxSpeed = 10;
        public float AsteroidMinSpeed = 1;

        public float AsteroidMinSize = 0.1f;
        public float AsteroidMaxSize = 1.0f;

        public int AsteroidsPerWave;
        public int AsteroidSpawnRate = 1;

        public int LifeTime = 10;

        public EntityManager EntityManager { get; private set; }
        public AsteroidBaker asteroidBaker;

        void Start()
        {
            EntityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            asteroidBaker = new AsteroidBaker();
        }
    }

    public class AsteroidBaker : Baker<AsteroidManager>
    {
        public override void Bake(AsteroidManager authoring)
        {
            // Set the stats to be random before initializing them in AddComponent
            Entity asteroidEntity = GetEntity(TransformUsageFlags.Dynamic);
            float Speed = UnityEngine.Random.Range(authoring.AsteroidMinSpeed, authoring.AsteroidMaxSpeed);
            float Size = UnityEngine.Random.Range(authoring.AsteroidMinSize, authoring.AsteroidMaxSize);
            int LifeTime = authoring.LifeTime;
            int WaveSize = authoring.AsteroidsPerWave;
            int NumberOfAsteroids = authoring.AmountOfAsteroids;
            int SpawnDelay = authoring.AsteroidSpawnRate;

            // Intialization of all asteroid entities that will be used, random stats are generated from the start
            // Each playthrough will have a different pool of asteroids that can appear
            // The extremities of these asteroids can be changed in the inspector

            AddComponent(asteroidEntity, new Asteroid
            {
                TotalNumberOfAsteroids = NumberOfAsteroids,
                AsteroidObject = GetEntity(authoring.AsteroidPrefab, TransformUsageFlags.Dynamic),
                AsteroidHealth = (int)Size * 3,
                AsteroidsPerWave = WaveSize,
                AsteroidSpeed = Speed,
                AsteroidLifeTime = LifeTime,
                AsteroidSize = Size,
                AsteroidSpawnDelay = SpawnDelay,
                LocalTransform = LocalTransform.Identity
                
            });
            AddComponent(asteroidEntity, new RandomGenerator
            {
                value = Unity.Mathematics.Random.CreateFromIndex(authoring.RandomSeed)
            });
            AddComponent<SpawnTimer>(asteroidEntity);

        }
    }
}

