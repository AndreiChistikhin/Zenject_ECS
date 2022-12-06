using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GameEndUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameEndPanel;
    [SerializeField] private Button _startAgainButton;

    private Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
        _player.OnEnemyTouched += EndGame;
        _startAgainButton.onClick.AddListener(StartNewGame);
    }

    private void OnDestroy()
    {
        _player.OnEnemyTouched -= EndGame;
        _startAgainButton.onClick.RemoveListener(StartNewGame);
    }

    private void EndGame()
    {
        _gameEndPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}