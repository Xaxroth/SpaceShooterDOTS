using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using System;
using UnityEditor.Build.Pipeline.Interfaces;

namespace SpaceShooter.DOTS
{
    //public struct Asteroid : IComponentData
    //{
    //    move this to seperate script?
    //    public Entity AsteroidObject;

    //    public int AsteroidHealth;
    //    public int AsteroidSpeed;
    //    public int AsteroidSize;
    //    public int AsteroidLifeTime;
    //}

    public class AsteroidManager : MonoBehaviour
    {
        public int AmountOfAsteroids;
        public int AsteroidsToSpawn;
        public GameObject[] SpawnableAsteroids;

        // VERY IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public GameObject AsteroidPrefab;
        // VERY IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Entity AsteroidEntity;

        public int AsteroidMaxHealth = 100;
        public int AsteroidMinHealth = 1;

        public int AsteroidMaxSpeed = 10;
        public int AsteroidMinSpeed = 1;

        public int AsteroidMinSize = 1;
        public int AsteroidMaxSize = 5;

        public int LifeTime = 10;

        public EntityManager EntityManager { get; private set; }
        public AsteroidBaker asteroidBaker;

        void Start()
        {
            AmountOfAsteroids = AsteroidsToSpawn;
            // Get the EntityManager from the World
            EntityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            // Initialize the asteroid baker with the EntityManager
            asteroidBaker = new AsteroidBaker();
        }
    }

    public class AsteroidBaker : Baker<AsteroidManager>
    {
        public override void Bake(AsteroidManager authoring)
        {
            Entity asteroidEntity = GetEntity(TransformUsageFlags.Dynamic);
            int Speed = UnityEngine.Random.Range(authoring.AsteroidMinSpeed, authoring.AsteroidMaxSpeed);
            int Size = UnityEngine.Random.Range(authoring.AsteroidMinSize, authoring.AsteroidMaxSize);
            int LifeTime = authoring.LifeTime;

            // Intialization of all asteroid entities that will be used, random stats are generated from the start
            // Each playthrough will have a different pool of asteroids that can appear
            // The extremities of these asteroids can be changed in the inspector

            AddComponent(asteroidEntity, new Asteroid
            {
                TotalNumberOfAsteroids = 100,
                AsteroidObject = GetEntity(authoring.AsteroidPrefab, TransformUsageFlags.Dynamic),
                AsteroidHealth = Size * 3,
                AsteroidSpeed = Speed,
                AsteroidLifeTime = LifeTime,
                AsteroidSize = Size,
            });
        }
    }

    //    public class AsteroidBaker : Baker<AsteroidManager>
    //{
    //    private EntityManager entityManager;

    //    public AsteroidBaker(EntityManager entityManager)
    //    {
    //        this.entityManager = entityManager;
    //    }

    //    public override void Bake(AsteroidManager authoring)
    //    {
    //        int Speed = UnityEngine.Random.Range(authoring.AsteroidMinSpeed, authoring.AsteroidMaxSpeed);
    //        int Size = UnityEngine.Random.Range(authoring.AsteroidMinSize, authoring.AsteroidMaxSize);
    //        int LifeTime = authoring.LifeTime;

    //        // Intialization of all asteroid entities that will be used, random stats are generated from the start
    //        // Each playthrough will have a different pool of asteroids that can appear
    //        // The extremities of these asteroids can be changed in the inspector
    //        var asteroidEntity = entityManager.CreateEntity();

    //        entityManager.AddComponentData(asteroidEntity, new Asteroid
    //        {
    //            AsteroidHealth = Size * 3,
    //            AsteroidSpeed = Speed,
    //            AsteroidLifeTime = LifeTime,
    //            AsteroidSize = Size,
    //            AsteroidObject = GetEntity(authoring.AsteroidPrefab, TransformUsageFlags.Dynamic)
    //        });
    //    }
}

