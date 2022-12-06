using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public class StartNewGameSystem : IInitializeSystem
{
    private GameEntity _startGameButton;
    private GameEntity _menu;
    private IGroup<GameEntity> _enemies;
    private Contexts _contexts;
    
    public StartNewGameSystem(Contexts contexts)
    {
        _contexts = contexts;
        
    }

    public void Initialize()
    {
        _contexts.game.isMenu = true;
        _contexts.game.SetStartGameButton
            (_contexts.game.menuEntity.gameView.gameObject.GetComponentInChildren<Button>());
        _startGameButton = _contexts.game.startGameButtonEntity;
        _menu = _contexts.game.menuEntity;
        _enemies = _contexts.game.GetGroup(GameMatcher.Enemy);
        _startGameButton.startGameButton.value.onClick.AddListener(StartNewGame);
    }

    private void StartNewGame()
    {
        Time.timeScale = 1;
        GameEntity[] enemies=_enemies.GetEntities();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].gameView.gameObject.Unlink();
            GameObject.Destroy(enemies[i].gameView.gameObject);
            enemies[i].Destroy();
        }

        _menu.ReplaceEnable(false);
    }
}