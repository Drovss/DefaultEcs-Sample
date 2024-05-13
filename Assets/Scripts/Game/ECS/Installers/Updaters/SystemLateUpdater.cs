using System;
using DefaultEcs.System;
using UnityEngine;
using Zenject;

namespace Game.ECS.Installers.Updaters
{
    public class SystemLateUpdater : ILateTickable, IDisposable
    {
        private ISystem<float> _system;

        public SystemLateUpdater(ISystem<float> system)
        {
            _system = system;
        }

        public void LateTick()
        {
            _system.Update(Time.deltaTime);
        }

        public void Dispose()
        {
            _system?.Dispose();
        }
    }
}