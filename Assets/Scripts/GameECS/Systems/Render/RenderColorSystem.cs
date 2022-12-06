using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderColorSystem : ReactiveSystem<GameEntity>
{
    public RenderColorSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Color);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasColor && entity.hasGameView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            e.gameView.gameObject.GetComponent<Renderer>().material.color = e.color.color;
        }
    }
}