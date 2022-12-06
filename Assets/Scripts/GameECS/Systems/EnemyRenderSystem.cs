using Entitas;
using Entitas.Unity;
using UnityEngine;

public class EnemyRenderSystem : IExecuteSystem
{
    private float _enemySpawnCoolDown = 2;
    private float _enemyTimeAlive = 7;
    private float _currentTime;
    private Contexts _contexts;

    public EnemyRenderSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _enemySpawnCoolDown)
        {
            SpawnEnemy();
            _currentTime = 0;
        }
    }

    private void SpawnEnemy()
    {
        GameEntity e = _contexts.game.CreateEntity();
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        e.AddGameView(go);
        go.Link(e);
        e.ReplaceObjectPosition(ReturnRandomPositionWithinScreen());
        e.AddColor(Color.red);
        e.isEnemy = true;
        e.AddEnemyDestroyTimer(_enemyTimeAlive);
    }

    private Vector2 ReturnRandomPositionWithinScreen()
    {
        if (Camera.main == null)
            throw new MissingComponentException();
        float zPosition = -Camera.main.transform.position.z;

        Vector2 lowestPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, -zPosition));
        Vector2 highestPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, -zPosition));

        float randomX = Random.Range(lowestPoint.x, highestPoint.x);
        float randomY = Random.Range(lowestPoint.y, highestPoint.y);
        return new Vector2(randomX, randomY);
    }
}