using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace SpaceShooter.DOTS
{
public struct MovementSpeed : IComponentData
{
    public float Value;
}

    // Basically lets the system know what entities should be affected by the execute commands, for example, entites with this IComponent will be able to move.
    public struct PlayerTag : IComponentData { }

}
