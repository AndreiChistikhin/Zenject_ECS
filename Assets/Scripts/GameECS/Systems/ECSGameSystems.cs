public class ECSGameSystems : Feature
{
    public ECSGameSystems(Contexts contexts) : base("Systems")
    {
        Add(new PlayerRenderSystem(contexts));
        Add(new RenderColorSystem(contexts));
        Add(new RenderObjectPositionSystem(contexts));
        Add(new EmmitInputSystem(contexts));
        Add(new PlayerMovementSystem(contexts));
        Add(new EnemyRenderSystem(contexts));
        Add(new EnemyMovementSystem(contexts));
        Add(new EnemyDestroySystem(contexts));
        Add(new EnemyTouchPlayerCheckSystem(contexts));
        Add(new MenuRenderSystem(contexts));
        Add(new RenderEnableObjectSystem(contexts));
        Add(new StartNewGameSystem(contexts));
    }
}