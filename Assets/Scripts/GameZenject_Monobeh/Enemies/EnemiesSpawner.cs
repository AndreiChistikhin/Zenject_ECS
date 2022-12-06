using UnityEngine;

public class EnemiesSpawner : GenericSpawner<TestEnemy>, IUpdatable
{
    private readonly float _spawnTimeDecreasingCoefficient = 0.95f;
    private float _spawnTime = 3;
    private float _currentTime;
    private BordersCalculator _bordersCalculator;

    public EnemiesSpawner(GenericFactory<TestEnemy> factory, BordersCalculator bordersCalculator) : base(factory)
    {
        _bordersCalculator = bordersCalculator;
    }

    public void Tick()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _spawnTime)
        {
            _currentTime = 0;
            _spawnTime *= _spawnTimeDecreasingCoefficient;
            TestEnemy enemy = SpawnObject();
            enemy.transform.position = _bordersCalculator.ReturnRandomPositionWithinScreen();
        }
    }
}