using Entitas;
using UnityEngine;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    readonly InputContext _context;
    private InputEntity _leftMouseEntity;
    private InputEntity _rightMouseEntity;

    public EmitInputSystem(Contexts contexts)
    {
        _context = contexts.input;
    }

    public void Initialize()
    {
        // initialize the unique entities that will hold the mouse button data
        _context.isLeftMouse = true;
        _leftMouseEntity = _context.leftMouseEntity;

        _context.isRightMouse = true;
        _rightMouseEntity = _context.rightMouseEntity;
    }

    public void Execute()
    {
        // mouse position
        Vector3 mousePositionInSpace = UnityEngine.Input.mousePosition;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(
            new Vector3(mousePositionInSpace.x,mousePositionInSpace.y,-Camera.main.transform.position.z));

        // left mouse button
        if (UnityEngine.Input.GetMouseButtonDown(0))
            _leftMouseEntity.ReplaceMouseDown(mousePosition);
        
        if (UnityEngine.Input.GetMouseButton(0))
            _leftMouseEntity.ReplaceMousePosition(mousePosition);
        
        if (UnityEngine.Input.GetMouseButtonUp(0))
            _leftMouseEntity.ReplaceMouseUp(mousePosition);
        

        // right mouse button
        if (UnityEngine.Input.GetMouseButtonDown(1))
            _rightMouseEntity.ReplaceMouseDown(mousePosition);
        
        if (UnityEngine.Input.GetMouseButton(1))
            _rightMouseEntity.ReplaceMousePosition(mousePosition);
        
        if (UnityEngine.Input.GetMouseButtonUp(1))
            _rightMouseEntity.ReplaceMouseUp(mousePosition);
        
    }
}