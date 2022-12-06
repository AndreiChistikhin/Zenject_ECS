using Entitas;
using Entitas.Unity;
using UnityEngine;

public class PlayerRenderSystem : IInitializeSystem
{
    private Contexts _contexts;
    private GameEntity _player;

    public PlayerRenderSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.game.isPlayer = true;
        _player = _contexts.game.playerEntity;
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _player.AddGameView(go);
        go.Link(_player);
        _player.AddObjectPosition(new Vector2());
        _player.AddColor(Color.white);
    }
}