using Unity.Entities;
using Unity;
using UnityEngine;
using System;
using Unity.Transforms;
using Unity.Mathematics;

public struct Player : IComponentData
{
    public Entity PlayerObject;

    public LocalTransform LocalTransform;
}
