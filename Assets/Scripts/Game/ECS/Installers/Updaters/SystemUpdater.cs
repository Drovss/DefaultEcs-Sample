using System;
using DefaultEcs.System;
using UnityEngine;
using Zenject;

namespace Game.ECS.Installers.Updaters
{
    public class SystemUpdater : ITickable, IDisposable
    {
        private ISystem<float> _system;

        public SystemUpdater(ISystem<float> system)
        {
            _system = system;
        }

        public void Tick()
        {
            _system.Update(Time.deltaTime);
        }

        public void Dispose()
        {
            _system?.Dispose();
        }
    }
}