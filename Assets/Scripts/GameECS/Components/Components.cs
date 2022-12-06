using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

[Game]
public class GameViewComponent : IComponent
{
    public GameObject gameObject;
}

[Game, Unique]
public class PlayerComponent : IComponent
{
    
}

[Game]
public class EnemyComponent : IComponent
{
    
}

[Game]
public class EnemyDestroyTimer : IComponent
{
    public float timeLeft;
}

[Game]
public class ColorComponent : IComponent
{
    public Color color;
}

[Game]
public class ObjectPositionComponent : IComponent
{
    public Vector3 position;
}

[Game, Unique]
public class MouseComponent : IComponent
{
    
}

[Game]
public class MouseCurrentPositionComponent : IComponent
{
    public Vector3 position;
}

[Game, Unique]
public class Menu : IComponent
{
    
}

[Game]
public class Enable : IComponent
{
    public bool value;
}

[Game, Unique]
public class StartGameButton : IComponent
{
    public Button value;
}