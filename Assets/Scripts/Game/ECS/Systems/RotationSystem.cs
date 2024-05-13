using DefaultEcs;
using DefaultEcs.System;
using Game.ECS.Components;
using UnityEngine;

namespace Game.ECS.Systems
{
    public class RotationSystem : AEntitySetSystem<float>
    {
        private readonly EntitySet _enemySet;

        public RotationSystem(World world)
            : base(world.GetEntities()
                .With<TransformComponent>()
                .With<RotationSpeedComponent>()
                .AsSet())
        {
        }

        protected override void Update(float state, in Entity entity)
        {
            ref var transformComponent = ref entity.Get<TransformComponent>();
            ref var rotationSpeedComponent = ref entity.Get<RotationSpeedComponent>();

            var rotation = Vector3.forward * state * rotationSpeedComponent.Speed;
            
            transformComponent.Transform.Rotate(rotation);
        }
    }
}