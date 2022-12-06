using Entitas;
using UnityEngine;

public class PlayerMovementSystem : IExecuteSystem
{
    private Contexts _contexts;
    private GameEntity _player;
    
    public PlayerMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
        contexts.game.isPlayer = true;
        _player = contexts.game.playerEntity;
    }
    
    public void Execute()
    {
        Vector3 mouseCurrentPosition = _contexts.game.mouseEntity.mouseCurrentPosition.position;
        if (Camera.main != null)
        {
            mouseCurrentPosition.z = -Camera.main.transform.position.z;
            _player.ReplaceObjectPosition(Camera.main.ScreenToWorldPoint(mouseCurrentPosition));
        }
    }
}
