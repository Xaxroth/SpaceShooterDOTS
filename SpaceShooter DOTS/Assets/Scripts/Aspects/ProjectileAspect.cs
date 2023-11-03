using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace SpaceShooter.DOTS
{
    public readonly partial struct ProjectileAspect : IAspect
    {
        public readonly Entity ProjectileEntity;
        private readonly RefRO<ProjectileTag> _projectile;
        private readonly RefRW<LocalTransform> _localTransform;
        private readonly RefRO<ProjectileComponent> _component;

        public float3 GetPosition
        {
            get => _localTransform.ValueRO.Position;
            set => _localTransform.ValueRW.Position = value;
        }
    }
}
