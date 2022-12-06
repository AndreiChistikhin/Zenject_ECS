using Entitas;
using UnityEngine;

[Game, Input, UI]
public class DestroyedComponent : IComponent 
{
}

[Game, Input, UI]
public class ViewDestroyComponent : IComponent 
{
    public GameObject gameObject;
}
