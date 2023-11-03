using SpaceShooter.DOTS;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace SpaceShooter.DOTS
{
    public class AsteroidMono : MonoBehaviour
    {
        public float AsteroidSpeed = 0f;
        public uint RandomSeed = 0;
        public float AsteroidMinSize = 0.1f;
        public float AsteroidMaxSize = 1f;
    }
}
public class AsteroidBaker : Baker<AsteroidMono>
{
    public override void Bake(AsteroidMono authoring)
    {
        
        Entity asteroidEntity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(asteroidEntity, new Asteroid
        {
            AsteroidSpeed = authoring.AsteroidSpeed
        });
        AddComponent(asteroidEntity, new RandomGenerator
        {
            value = Unity.Mathematics.Random.CreateFromIndex(authoring.RandomSeed)
        });
        AddComponent<AsteroidTag>(asteroidEntity);
        AddComponent<SpawnTimer>(asteroidEntity);
    }
}
