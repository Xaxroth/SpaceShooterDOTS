using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using System;

namespace SpaceShooter.DOTS
{
    public struct Asteroid : IComponentData
    {
        public int AsteroidHealth;
        public int AsteroidSpeed;
        public int AsteroidSize;
        public int AsteroidLifeTime;
        public int AsteroidType;
        //public GameObject AsteroidObject;
    }

    public class AsteroidManager : MonoBehaviour
    {
        public int MaximumAmountOfAsteroids;
        public int AmountOfAsteroids;
        public int AsteroidsToSpawn;
        public GameObject[] SpawnableAsteroids;
        
        public GameObject AsteroidPrefab;

        public int AsteroidMaxHealth = 100;
        public int AsteroidMinHealth = 1;

        public int AsteroidMaxSpeed = 10;
        public int AsteroidMinSpeed = 1;

        public int LifeTime = 10;
    }

    public class AsteroidBaker : Baker<AsteroidManager>
    {
        public override void Bake(AsteroidManager authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);

            int Health = UnityEngine.Random.Range(authoring.AsteroidMinHealth, authoring.AsteroidMaxHealth);
            int Speed = UnityEngine.Random.Range(authoring.AsteroidMinSpeed, authoring.AsteroidMaxSpeed);
            int LifeTime = authoring.LifeTime;
            Debug.Log("jag var ute och gick en natt");

            AddComponent(entity, new Asteroid
            {
                AsteroidHealth = Health,
                AsteroidSpeed = Speed,
                AsteroidLifeTime = LifeTime,
                //AsteroidObject = authoring.AsteroidPrefab


                

                 
            });
        }
    }
}
