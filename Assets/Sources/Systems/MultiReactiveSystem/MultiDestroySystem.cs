using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

// IDestroyed: "I'm an Entity, I can have a DestroyedComponent"
public interface IDestroyableEntity : IEntity, IDestroyedEntity { }

// tell the compiler that our context-specific entities implement IDestroyed
public partial class GameEntity : IDestroyableEntity { }
public partial class InputEntity : IDestroyableEntity { }
public partial class UIEntity : IDestroyableEntity { }

// inherit from MultiReactiveSystem using the IDestroyed interface defined above
public class MultiDestroySystem : MultiReactiveSystem<IDestroyableEntity, Contexts>
{
    // base class takes in all contexts, not just one as in normal ReactiveSystems
    public MultiDestroySystem(Contexts contexts) : base(contexts)
    {
    }

    // return an ICollector[] with a collector from each context
    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[] {
            contexts.game.CreateCollector(GameMatcher.Destroyed),
            contexts.input.CreateCollector(InputMatcher.Destroyed),
            contexts.uI.CreateCollector(UIMatcher.Destroyed)
        };
    }

    protected override bool Filter(IDestroyableEntity entity)
    {
        return entity.isDestroyed;
    }

    protected override void Execute(List<IDestroyableEntity> entities)
    {
        foreach (var e in entities)
        {
            Debug.Log("Destroyed Entity from " + e.contextInfo.name + " context");
            e.Destroy();
        }
    }
}