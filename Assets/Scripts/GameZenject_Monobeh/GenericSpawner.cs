using UnityEngine;

public class GenericSpawner<T> where T:Object
{
    private GenericFactory<T> _factory;

    public GenericSpawner(GenericFactory<T> factory)
    {
        _factory = factory;
    }

    public T SpawnObject()
    {
        return _factory.Create();
    }
}
