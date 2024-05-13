using DefaultEcs;
using UnityEngine;

namespace Game.ECS.Model
{
    public class EntityBase : MonoBehaviour
    {
        public ABaseAdapter[] Adapters;
        
        public Entity Entity { get; private set; }

        public Entity CreateEntity(World world)
        {
            var entity = world.CreateEntity();

            Entity = entity;

            foreach (var adapter in Adapters)
            {
                adapter.Install(world, entity);
            }

            return entity;
        }
    }
}