using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCountDown : MonoBehaviour
{
    [SerializeField] private Text _countDownText;
    [SerializeField] private TestEnemy _enemy;

    private float _timeTillDeath;

    private void Start()
    {
        _timeTillDeath = _enemy.MaxAliveTime;
    }

    private void Update()
    {
        _timeTillDeath -= Time.deltaTime;
        _countDownText.text = Mathf.RoundToInt(_timeTillDeath).ToString(CultureInfo.InvariantCulture);
    }
}