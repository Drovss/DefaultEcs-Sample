using DefaultEcs;
using Game.ECS.Components;
using Game.ECS.Model;
using UnityEngine;

namespace Game.ECS.Adapters
{
    public class RotationSpeedAdapter : EntityBaseComponent<RotationSpeedComponent>
    {
        [SerializeField] private float _speed;

        public override void Install(World world, Entity entity)
        {
            base.Install(world, entity);

            ref var component = ref Entity.Get<RotationSpeedComponent>();

            component.Speed = _speed;
        }
    }
}