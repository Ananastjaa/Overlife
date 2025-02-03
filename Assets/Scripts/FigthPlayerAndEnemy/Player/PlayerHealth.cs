using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public double Health { get { return _currentHealth; } }

    [SerializeField] private Toggle _playerCanGetDamageToggle;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Coroutine _regenerationCoroutine;
    private double _currentHealth;
    private Color _hitColor = new Color(0.92f, 0.45f, 0.48f);    // !!!MOWE WORK WITH UI ELEMENTS TO ANOTHER CLASS!!!
    private GameOverHandler _gameOverHanler;
    private PlayerStats _playerStats;

    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _gameOverHanler = FindObjectOfType<GameOverHandler>();
        _currentHealth = _playerStats.MaxHealth;
    }

    public void GetDemage(double demage)
    {
        if (_playerCanGetDamageToggle.isOn)
        {
            _currentHealth -= demage;
            _healthBar.SetHealthBar(_currentHealth, _playerStats.MaxHealth);
            StartCoroutine(MakePlayeRedForAMoment());

            if (_currentHealth <= 0)
            {
                _gameOverHanler.GameOver();
            }


            if (_regenerationCoroutine != null)
            {
                StopCoroutine(_regenerationCoroutine);                        // control regeneretion time
            }
            _regenerationCoroutine = StartCoroutine(RegenerateHealth());
        }
    }

    private IEnumerator MakePlayeRedForAMoment()
    {
        _spriteRenderer.color = _hitColor;
        yield return new WaitForSeconds(0.2f);
        _spriteRenderer.color = Color.white;
    }

    private IEnumerator RegenerateHealth()
    {
        yield return new WaitForSeconds(_playerStats.TimeToStartRegeneration);

        while (_currentHealth < _playerStats.MaxHealth)
        {
            _currentHealth += _playerStats.XpOfHealthRegenerationPerInterval;
            if (_currentHealth > _playerStats.MaxHealth) _currentHealth = _playerStats.MaxHealth;
            _healthBar.SetHealthBar(_currentHealth, _playerStats.MaxHealth);
            yield return new WaitForSeconds(_playerStats.RegenerationInterval);
        }

        _regenerationCoroutine = null; // Stop the coroutine when health is fully regenerated
    }
}
