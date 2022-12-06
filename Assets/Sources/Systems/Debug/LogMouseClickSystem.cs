using Entitas;

public class LogMouseClickSystem : IExecuteSystem
{
    readonly GameContext _context;

    public LogMouseClickSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            _context.CreateEntity().AddDebugMessage("Left Mouse Button Clicked");
        }

        if (UnityEngine.Input.GetMouseButtonDown(1))
        {
            _context.CreateEntity().AddDebugMessage("Right Mouse Button Clicked");
        }
    }
}
