using System;
using DefaultEcs.System;
using UnityEngine;
using Zenject;

namespace Game.ECS.Installers.Updaters
{
    public class SystemFixedUpdater : IFixedTickable, IDisposable
    {
        private ISystem<float> _system;

        public SystemFixedUpdater(ISystem<float> system)
        {
            _system = system;
        }

        public void FixedTick()
        {
            _system.Update(Time.fixedDeltaTime);
        }

        public void Dispose()
        {
            _system?.Dispose();
        }
    }
}