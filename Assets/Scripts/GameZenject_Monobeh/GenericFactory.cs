using UnityEngine;
using Zenject;

public abstract class GenericFactory<T> where T:Object
{
    private DiContainer _diContainer;

    public DiContainer DiContainer => _diContainer;

    public GenericFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public abstract T Create();
}
