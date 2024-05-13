using DefaultEcs;
using Game.ECS.Components;
using Zenject;

namespace Game.ECS.Installers
{
    public class EcsInstaller : MonoInstaller
    {
        private World _world;

        public override void InstallBindings()
        {
            _world = new World();
            
            _world.Set<WorldComponent>();

            Container
                .Bind<World>()
                .FromInstance(_world);
        }
    }
}