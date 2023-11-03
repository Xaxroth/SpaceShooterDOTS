using Unity.Entities;
using Unity;
using UnityEngine;
using System;
using Unity.Transforms;
using Unity.Mathematics;

public struct ProjectileComponent : IComponentData
{
    public Entity ProjectileObject;

    public LocalTransform LocalTransform;

    public float ProjectileSpeed;
}
