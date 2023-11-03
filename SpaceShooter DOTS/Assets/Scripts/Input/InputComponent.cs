using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace SpaceShooter.DOTS
{
    public struct InputComponent : IComponentData
    {
        public float2 Value;
    }

    public struct FireProjectileTag : IComponentData, IEnableableComponent { }

}
