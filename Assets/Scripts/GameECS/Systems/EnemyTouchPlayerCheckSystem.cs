using Entitas;
using UnityEngine;

public class EnemyTouchPlayerCheckSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _enemies;
    private GameEntity _player;
    private GameEntity _menu;

    public EnemyTouchPlayerCheckSystem(Contexts contexts)
    {
        _contexts = contexts;
        _enemies = contexts.game.GetGroup(GameMatcher.Enemy);
        _contexts.game.isPlayer = true;
        _player = contexts.game.playerEntity;
        _contexts.game.isMenu = true;
        _menu = contexts.game.menuEntity;
    }

    public void Execute()
    {
        foreach (GameEntity e in _enemies)
        {
            float distance = (e.objectPosition.position - _player.objectPosition.position).magnitude;
            if (distance <= 1)
            {
                _menu.ReplaceEnable(true);
                Time.timeScale = 0;
            }
        }
    }
}