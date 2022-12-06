using UnityEngine;
using Zenject;

public class EnemiesFactory : GenericFactory<TestEnemy>
{
    public EnemiesFactory(DiContainer diContainer) : base(diContainer)
    {
    }

    public override TestEnemy Create()
    {
        return DiContainer.InstantiatePrefabResourceForComponent<TestEnemy>("Enemy", Vector3.zero, Quaternion.identity,
            null);
    }
}