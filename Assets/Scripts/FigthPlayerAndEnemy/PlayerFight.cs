using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI; 

public class PlayerFight : MonoBehaviour
{
    public static Action<double> PlayerAttack;
    public double Health { get { return _currentHealth; } }

    [SerializeField] private double _maxHealth;
    [SerializeField] private double _demage;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Toggle _playerCanGetDamageToggle;
    [SerializeField] private HealthBar _healthBar;

    private double _currentHealth;

    // health regeneration variable. maybe need to make make new class later
    private double regenAmount = 1; 
    private float _timeToStartRegeneration = 5f, _regenerationInterval = 1f; 
    private Coroutine _regenerationCoroutine;

    private Color _hitColor = new Color(0.92f, 0.45f, 0.48f);
    private GameOverHandler _gameOverHanler;

    public void Start()
    {
        _gameOverHanler = FindObjectOfType<GameOverHandler>();
        _currentHealth = _maxHealth;
    }

    public void GetDemage(double demage)
    {
        if (_playerCanGetDamageToggle.isOn) 
        {
            _currentHealth -= demage;
            _healthBar.SetHealthBar(_currentHealth, _maxHealth);
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
    public void Attack()
    {
        PlayerAttack?.Invoke(_demage);
    }

    private IEnumerator MakePlayeRedForAMoment()
    {
        _spriteRenderer.color = _hitColor;
        yield return new WaitForSeconds(0.2f);
        _spriteRenderer.color = Color.white;
    }

    private IEnumerator RegenerateHealth()
    {
        yield return new WaitForSeconds(_timeToStartRegeneration);

        while (_currentHealth < _maxHealth)
        {
            _currentHealth += regenAmount;
            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
            _healthBar.SetHealthBar(_currentHealth, _maxHealth);
            yield return new WaitForSeconds(_regenerationInterval);
        }

        _regenerationCoroutine = null; // Stop the coroutine when health is fully regenerated
    }
}
