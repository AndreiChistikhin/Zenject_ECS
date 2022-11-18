using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private Input _input;
    [SerializeField] private EnemyMarker[] _enemyMarkers;

    private const string IDName = "HI";

    public override void InstallBindings()
    {
        BindInterfaces();
        BindInput();
        BindHero();
        BindEnemyFactory();
    }

    private void BindEnemyFactory()
    {
        Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        Container.Bind(typeof(IEnemyFactory)).To(typeof(EnemyFactory));
    }

    private void BindInterfaces()
    {
        Container.BindInterfacesTo<LocationInstaller>().FromInstance(this).AsSingle();
    }

    private void BindInput()
    {
        Container.Bind<Input>().WithId("HI").FromComponentInNewPrefab(_input).AsSingle();
    }

    private void BindHero()
    {
        PlayerTest playerTest =
            Container.InstantiatePrefabForComponent<PlayerTest>(_heroPrefab, _startPoint.position, Quaternion.identity,
                null);
        Container.BindInterfacesAndSelfTo<PlayerTest>().FromInstance(playerTest).NonLazy();
        Container.Bind<PlayerTest>().FromComponentInNewPrefab(_input).WithGameObjectName("Hello")
            .UnderTransform(_startPoint).WhenInjectedInto<Enemy>();
    }

    //Resolve - костыль для првоерки работоспособности
    public void Initialize()
    {
        var enemyFactory = Container.Resolve<IEnemyFactory>();
        foreach (var enemyMarker in _enemyMarkers)
        {
            enemyFactory.Create(enemyMarker.transform.position);
            Debug.Log("HI");
        }
    }
}

public interface IEnemyFactory
{
    void Create(Vector3 enemyPosition);
}

public class EnemyFactory : IEnemyFactory
{
    private DiContainer _diContainer;
    private Object _enemyPrefab;

    public EnemyFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public void Create(Vector3 enemyPosition)
    {
        _diContainer.InstantiatePrefab(_enemyPrefab, enemyPosition, Quaternion.identity, null);
    }
}