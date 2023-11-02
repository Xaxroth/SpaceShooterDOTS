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

    public class AsteroidBaker : Baker<AsteroidMono>
    {
            public override void Bake(AsteroidMono authoring)
            {
                Entity asteroidEntity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(asteroidEntity, new Asteroid
                {
                    AsteroidSpeed = authoring.AsteroidSpeed
                });
            }
    }
}

}
