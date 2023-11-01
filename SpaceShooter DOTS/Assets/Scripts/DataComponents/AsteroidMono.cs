using SpaceShooter.DOTS;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace SpaceShooter.DOTS
{
public class AsteroidMono : MonoBehaviour
{
    // The asteroid mono file, should handle asteroid stats
    public float AsteroidSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {

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
            }
    }
}

}
