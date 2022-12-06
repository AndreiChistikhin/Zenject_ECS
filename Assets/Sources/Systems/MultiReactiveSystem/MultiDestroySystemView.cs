using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

// IDestroyed: "I'm an Entity, I can have a DestroyedComponent AND I can have a ViewComponent"
public interface IDestroyableViewEntity : IEntity, IDestroyedEntity, IViewDestroyEntity { }

// tell the compiler that our context-specific entities implement IDestroyed
public partial class GameEntity : IDestroyableViewEntity { }
public partial class InputEntity : IDestroyableViewEntity { }
public partial class UIEntity : IDestroyableViewEntity { }

// inherit from MultiReactiveSystem using the IDestroyed interface defined above
public class MultiDestroyViewSystem : MultiReactiveSystem<IDestroyableViewEntity , Contexts>
{
    public MultiDestroyViewSystem(Contexts contexts) : base(contexts)
    {
    }

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[] {
            contexts.game.CreateCollector(GameMatcher.Destroyed),
            contexts.input.CreateCollector(InputMatcher.Destroyed),
            contexts.uI.CreateCollector(UIMatcher.Destroyed)
        };
    }

    protected override bool Filter(IDestroyableViewEntity entity)
    {
        return entity.isDestroyed;
    }

    protected override void Execute(List<IDestroyableViewEntity> entities)
    {
        foreach (var e in entities)
        {
            // now we can access the ViewComponent and the DestroyedComponent
            if (e.hasViewDestroy)
            {
                GameObject go = e.viewDestroy.gameObject;
                go.Unlink();
                Object.Destroy(go);
            }
            Debug.Log("Destroyed Entity from " + e.contextInfo.name + " context");
            e.Destroy();
        }
    }
}