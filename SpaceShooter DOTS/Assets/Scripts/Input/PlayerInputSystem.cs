using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShooter.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class PlayerInputSystem : SystemBase
    {
        private PlayerInputAction _actions;
        private Entity _player;
        protected override void OnCreate()
        {
            _actions = new PlayerInputAction();

            RequireForUpdate<PlayerTag>();
            RequireForUpdate<InputComponent>();
        }
        protected override void OnUpdate()
        {
            var CurrentInput = _actions.Player.PlayerMovement.ReadValue<Vector2>();
            SystemAPI.SetSingleton(new InputComponent{ Value = CurrentInput });
        }

        protected override void OnStartRunning()
        {
            _actions.Enable();
            _player = SystemAPI.GetSingletonEntity<PlayerTag>();
        }

        protected override void OnStopRunning()
        {
            _actions.Disable();
            _player = Entity.Null;
        }

        private void Shoot(InputAction.CallbackContext Object)
        {
            if (!SystemAPI.Exists(_player)) return;

            SystemAPI.SetComponentEnabled<ProjectileComponent>(_player, true);
        }
    }
}
