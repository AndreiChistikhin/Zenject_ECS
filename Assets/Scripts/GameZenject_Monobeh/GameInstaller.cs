using Zenject;

public class GameInstaller : MonoInstaller
{
    private EnemiesSpawner _spawner;
    public override void InstallBindings()
    {
        BindContainer();
    }

    private void BindContainer()
    {
        Container.BindInterfacesAndSelfTo<GameInstaller>().FromInstance(this).AsSingle();
        Container.Bind<GenericFactory<Player>>().To<PlayerFactory>().AsSingle();
        Container.Bind<GenericSpawner<Player>>().To<PlayerSpawner>().AsSingle().NonLazy();
        Container.Bind<GenericFactory<TestEnemy>>().To<EnemiesFactory>().AsSingle();
        Container.Bind(typeof(GenericSpawner<TestEnemy>),typeof(IUpdatable)).To<EnemiesSpawner>().AsSingle().NonLazy();
        Container.Bind<BordersCalculator>().AsSingle();
    }
}