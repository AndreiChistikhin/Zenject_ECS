using System.Collections.Generic;
using Entitas;

public class RenderObjectPositionSystem : ReactiveSystem<GameEntity>
{
    public RenderObjectPositionSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ObjectPosition);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasObjectPosition && entity.hasGameView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            e.gameView.gameObject.transform.position = e.objectPosition.position;
        }
    }
}