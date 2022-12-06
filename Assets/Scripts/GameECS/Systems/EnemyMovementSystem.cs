using Entitas;
using UnityEngine;

public class EnemyMovementSystem : IExecuteSystem
{
    private readonly int _playerSpeed = 10;
    private Contexts _contexts;
    private GameEntity _player;
    private IGroup<GameEntity> _enemies;

    public EnemyMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
        contexts.game.isPlayer = true;
        _player = contexts.game.playerEntity;
        _enemies = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute()
    {
        foreach (GameEntity e in _enemies)
        {
            Vector3 direction = (_player.objectPosition.position - e.objectPosition.position).normalized;
            Vector3 newPosition = e.objectPosition.position + direction * Time.deltaTime * _playerSpeed;
            e.ReplaceObjectPosition(newPosition);
        }
    }
}