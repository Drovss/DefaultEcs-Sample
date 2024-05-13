using DefaultEcs;
using DefaultEcs.System;
using Game.ECS.Installers.Updaters;
using Game.ECS.Systems;
using Zenject;

namespace Game.ECS.Installers
{
    public class SystemsInstaller : MonoInstaller
    {
        [Inject] private World _world;
        
        private ISystem<float> _updateSystem;
        private ISystem<float> _fixedUpdateSystem;
        private ISystem<float> _lateUpdateSystem;

        public override void InstallBindings()
        {
            _updateSystem = new SequentialSystem<float>(
                new RotationSystem(_world)
                // update systems
            );
        
            _fixedUpdateSystem = new SequentialSystem<float>(
                // fixed update systems
            );
        
            _lateUpdateSystem = new SequentialSystem<float>(
                // late update systems
            );

            SystemUpdater systemUpdater = new SystemUpdater(_updateSystem);
            SystemFixedUpdater systemFixedUpdater = new SystemFixedUpdater(_fixedUpdateSystem);
            SystemLateUpdater systemLateUpdater = new SystemLateUpdater(_lateUpdateSystem);

            Container
                .BindInterfacesAndSelfTo<SystemUpdater>()
                .FromInstance(systemUpdater)
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<SystemFixedUpdater>()
                .FromInstance(systemFixedUpdater)
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<SystemLateUpdater>()
                .FromInstance(systemLateUpdater)
                .AsSingle();

        }
    }
}