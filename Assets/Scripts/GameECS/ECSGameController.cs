using Entitas;
using UnityEngine;

public class ECSGameController : MonoBehaviour
{
    private Systems _systems;
    private Contexts _contexts;

    void Start()
    {
        _contexts = Contexts.sharedInstance;
        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private static Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems")
            .Add(new ECSGameSystems(contexts));
    }

}
