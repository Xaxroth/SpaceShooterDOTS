using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

namespace SpaceShooter.DOTS
{
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct PlayerMovementManager : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            new PlayerMoveJob
            {
                DeltaTime = deltaTime

            }.Schedule();
        }
    }

    [BurstCompile]
    public partial struct PlayerMoveJob : IJobEntity
    {
        public float DeltaTime;

        [BurstCompile]
        private void Execute (ref LocalTransform transform, in InputComponent inputComponent, MovementSpeed moveSpeed)
        {
            transform.Position.xy += inputComponent.Value * moveSpeed.Value * DeltaTime;
            if (math.lengthsq(inputComponent.Value) > float.Epsilon)
            {
                Debug.Log("WHERE'S THE FUCKING AMMUNITION");
                //var forward = new float3(inputComponent.Value.x, 0f, inputComponent.Value.y);
                //transform.Rotation = quaternion.LookRotation(forward, math.up());
            }
        }
    }
}
