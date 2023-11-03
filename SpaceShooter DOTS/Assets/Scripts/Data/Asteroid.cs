using Unity.Entities;
using Unity;
using UnityEngine;
using System;
using Unity.Transforms;
using Unity.Mathematics;

public struct Asteroid : IComponentData
{
    public Entity AsteroidObject;

    public LocalTransform LocalTransform;

    public int AsteroidHealth;
    public float AsteroidSpeed;
    public float AsteroidSize;
    public int AsteroidLifeTime;
    public int AsteroidSpawnDelay;

    public int AsteroidsPerWave;
    public int TotalNumberOfAsteroids;
}