//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public ViewDestroyComponent viewDestroy { get { return (ViewDestroyComponent)GetComponent(InputComponentsLookup.ViewDestroy); } }
    public bool hasViewDestroy { get { return HasComponent(InputComponentsLookup.ViewDestroy); } }

    public void AddViewDestroy(UnityEngine.GameObject newGameObject) {
        var index = InputComponentsLookup.ViewDestroy;
        var component = (ViewDestroyComponent)CreateComponent(index, typeof(ViewDestroyComponent));
        component.gameObject = newGameObject;
        AddComponent(index, component);
    }

    public void ReplaceViewDestroy(UnityEngine.GameObject newGameObject) {
        var index = InputComponentsLookup.ViewDestroy;
        var component = (ViewDestroyComponent)CreateComponent(index, typeof(ViewDestroyComponent));
        component.gameObject = newGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveViewDestroy() {
        RemoveComponent(InputComponentsLookup.ViewDestroy);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity : IViewDestroyEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherViewDestroy;

    public static Entitas.IMatcher<InputEntity> ViewDestroy {
        get {
            if (_matcherViewDestroy == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.ViewDestroy);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherViewDestroy = matcher;
            }

            return _matcherViewDestroy;
        }
    }
}
