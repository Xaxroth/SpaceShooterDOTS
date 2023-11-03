using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter.DOTS
{
    public struct RandomGenerator : IComponentData
    {
        public Random value;
    }
}
