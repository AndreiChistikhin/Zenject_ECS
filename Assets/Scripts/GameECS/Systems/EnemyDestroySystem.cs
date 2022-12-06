using Entitas;
using Entitas.Unity;
using UnityEngine;

public class EnemyDestroySystem : IExecuteSystem
{
    private IGroup<GameEntity> _enemies;

    public EnemyDestroySystem(Contexts contexts)
    {
        _enemies = contexts.game.GetGroup(GameMatcher.EnemyDestroyTimer);
    }
    
    public void Execute()
    {
        foreach (GameEntity e in _enemies)
        {
            float oldTime = e.enemyDestroyTimer.timeLeft;
            float newTime = oldTime - Time.deltaTime;
            if (newTime <= 0)
            {
                GameObject.Destroy(e.gameView.gameObject);
                e.gameView.gameObject.Unlink();
                e.Destroy();
                return;
            }
            e.ReplaceEnemyDestroyTimer(newTime);
        }
    }
}