using Entitas;

public class EmmitInputSystem : IInitializeSystem, IExecuteSystem
{
    private Contexts _contexts;
    private GameEntity _mouse;

    public EmmitInputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.game.isMouse = true;
        _mouse = _contexts.game.mouseEntity;
    }

    public void Execute()
    {
        _mouse.ReplaceMouseCurrentPosition(UnityEngine.Input.mousePosition);
    }
}