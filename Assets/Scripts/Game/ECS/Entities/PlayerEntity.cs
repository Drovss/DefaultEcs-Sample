using Game.ECS.Components;
using UnityEngine;

namespace Game.ECS.Entities
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _rotationSpeed;

        private void Start()
        {
            var playerEntity = EcsBootstrapper.World.CreateEntity();

            var transformComponent = new TransformComponent();
            transformComponent.Transform = _transform;
            playerEntity.Set(transformComponent);
            
            var rotationSpeedComponent = new RotationSpeedComponent();
            rotationSpeedComponent.Speed = _rotationSpeed;
            playerEntity.Set(rotationSpeedComponent);
        }
    }
}