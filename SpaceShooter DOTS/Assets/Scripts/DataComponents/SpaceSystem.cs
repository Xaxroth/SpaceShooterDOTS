using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Entities;
using Unity.Transforms;

namespace SpaceShooter.DOTS
{
    // The logistics struct, used for extended functionality.
    public readonly partial struct SpaceSystem : ISystem
    {
        public readonly Entity AsteroidEntity;

        private readonly RefRO<Asteroid> AsteroidProperties;

    }
}
