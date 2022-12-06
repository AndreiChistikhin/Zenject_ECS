using UnityEngine;
using Zenject;

public class PlayerFactory : GenericFactory<Player>
{
    public PlayerFactory(DiContainer diContainer) : base(diContainer)
    {
    }

    public override Player Create()
    {
        Player player = DiContainer.InstantiatePrefabResourceForComponent<Player>("Player", Vector3.zero, Quaternion.identity, null);
        DiContainer.Bind<Player>().FromInstance(player).AsSingle();
        DiContainer.Bind<Transform>().FromComponentOn(player.gameObject).WhenInjectedInto<TestEnemy>();
        return player;
    }
}