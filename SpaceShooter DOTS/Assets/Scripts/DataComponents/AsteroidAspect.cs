using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.Transforms;
using Unity.Entities;
using UnityEngine;

namespace SpaceShooter.DOTS
{
    public readonly partial struct AsteroidAspect : IAspect
    {
        public readonly Entity AsteroidEntity;
        private readonly RefRO<Asteroid> _asteroid;
        public Entity AsteroidPrefab => _asteroid.ValueRO.AsteroidObject;

        public int AsteroidsToSpawn => _asteroid.ValueRO.TotalNumberOfAsteroids;

        
    }
}
