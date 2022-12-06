using Zenject;

public class GameInstaller : MonoInstaller
{
    private EnemiesSpawner _spawner;
    public override void InstallBindings()
    {
        BindContainer();
        BindPlayer();
        BindEnemies();
        BindBorders();
    }

    private void BindContainer()
    {
        Container.BindInterfacesAndSelfTo<GameInstaller>().FromInstance(this).AsSingle();
    }

    private void BindPlayer()
    {
        Container.Bind<GenericFactory<Player>>().To<PlayerFactory>().AsSingle();
        Container.Bind<GenericSpawner<Player>>().To<PlayerSpawner>().AsSingle().NonLazy();
    }

    private void BindEnemies()
    {
        Container.Bind<GenericFactory<TestEnemy>>().To<EnemiesFactory>().AsSingle();
        Container.Bind(typeof(GenericSpawner<TestEnemy>), typeof(IUpdatable)).To<EnemiesSpawner>().AsSingle().NonLazy();
    }

    private void BindBorders()
    {
        Container.Bind<BordersCalculator>().AsSingle();
    }
}