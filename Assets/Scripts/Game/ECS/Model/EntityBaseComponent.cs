using DefaultEcs;
using UnityEngine;

namespace Game.ECS.Model
{
    public class EntityBaseComponent<T> : ABaseAdapter where T : struct
    {
        protected World World { get; private set; }
        protected Entity Entity { get; private set; }

        public override void Install(World world, Entity entity)
        {
            if (entity.Has<T>())
            {
                Debug.LogError($"Component already exists in entity {typeof(T)}", gameObject);
                
                return;
            }
            
            entity.Set<T>();

            World = world;
            Entity = entity;
        }
    }
}