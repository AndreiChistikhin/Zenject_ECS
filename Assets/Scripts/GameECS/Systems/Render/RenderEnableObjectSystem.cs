using System.Collections.Generic;
using Entitas;

public class RenderEnableObjectSystem : ReactiveSystem<GameEntity>
{
    public RenderEnableObjectSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Enable);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEnable && entity.hasGameView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            e.gameView.gameObject.SetActive(e.enable.value);
        }
    }
}
