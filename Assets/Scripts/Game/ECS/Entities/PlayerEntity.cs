using DefaultEcs;
using Game.ECS.Components;
using UnityEngine;
using Zenject;

namespace Game.ECS.Entities
{
    public class PlayerEntity : MonoBehaviour
    {
        [Inject] private World _world;
        
        [SerializeField] private Transform _transform;
        [SerializeField] private float _rotationSpeed;

        private void Start()
        {
            var playerEntity = _world.CreateEntity();

            var transformComponent = new TransformComponent();
            transformComponent.Transform = _transform;
            playerEntity.Set(transformComponent);
            
            var rotationSpeedComponent = new RotationSpeedComponent();
            rotationSpeedComponent.Speed = _rotationSpeed;
            playerEntity.Set(rotationSpeedComponent);
        }
    }
}