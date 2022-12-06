using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public class MenuRenderSystem : IInitializeSystem
{
    private GameEntity _menu;
    
    public MenuRenderSystem(Contexts contexts)
    {
        contexts.game.isMenu = true;
        _menu = contexts.game.menuEntity;
    }
    
    public void Initialize()
    {
        GameObject canvas = new GameObject("canvas");
        Canvas canvasComponent = canvas.AddComponent<Canvas>();
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();
        canvasComponent.renderMode = RenderMode.ScreenSpaceOverlay;
        GameObject go = (GameObject) Resources.Load("GameEndMenu");
        GameObject menu = GameObject.Instantiate(go, canvas.transform);
        menu.Link(_menu);
        _menu.AddGameView(menu);
        _menu.AddEnable(false);
    }
}
