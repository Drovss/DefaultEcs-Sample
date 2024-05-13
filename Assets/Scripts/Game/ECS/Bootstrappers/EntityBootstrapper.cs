using System;
using DefaultEcs;
using Game.ECS.Model;
using UnityEngine;
using Zenject;

namespace Game.ECS.Bootstrappers
{
    public class EntityBootstrapper : MonoBehaviour
    {
        [Inject] private World _world;

        [SerializeField] private EntityBase _entityBase;

        [Header("For Debug")] public int EntityId;

        private void OnEnable()
        {
            var entity = _entityBase.CreateEntity(_world);

            EntityId = entity.GetHashCode();
        }

        private void OnDisable()
        {
            _entityBase.Entity.Dispose();
        }
    }
}