using Unity.Entities;
using Unity;
using UnityEngine;
using System;

public struct Asteroid : IComponentData
{
    public Entity AsteroidObject;

    public int AsteroidHealth;
    public int AsteroidSpeed;
    public int AsteroidSize;
    public int AsteroidLifeTime;

    public int TotalNumberOfAsteroids;
}