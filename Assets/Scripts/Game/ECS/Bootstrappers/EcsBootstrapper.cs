using DefaultEcs;
using DefaultEcs.System;
using Game.ECS.Systems;
using UnityEngine;

public class EcsBootstrapper : MonoBehaviour
{
    public static World World { get; private set; }

    private ISystem<float> _updateSystem;
    private ISystem<float> _fixedUpdateSystem;
    private ISystem<float> _lateUpdateSystem;
    
    private void Awake()
    {
        World = new World();

        _updateSystem = new SequentialSystem<float>(
            new RotationSystem(World)
            // update systems
        );
        
        _fixedUpdateSystem = new SequentialSystem<float>(
            // fixed update systems
        );
        
        _lateUpdateSystem = new SequentialSystem<float>(
            // late update systems
        );
    }

    
    private void Update()
    {
        _updateSystem.Update(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _fixedUpdateSystem.Update(Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        _lateUpdateSystem.Update(Time.deltaTime);
    }

    private void OnDestroy()
    {
        World.Dispose();
    }
}
