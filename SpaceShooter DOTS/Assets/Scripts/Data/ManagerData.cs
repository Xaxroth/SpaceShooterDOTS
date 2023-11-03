using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter.DOTS
{
    public struct ManagerData : IComponentData
    {
        public float2 PlayArea;
        public float AsteroidSpawnRate;
    }

    public struct SpawnTimer : IComponentData
    {
        public float Value;
    }
}
