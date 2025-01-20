using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerFight : MonoBehaviour
{
    public static Action<double> PlayerAttack;
    public static bool IsMeleeMode { get { return _isMeleeMode; } } 
    public double Health { get { return _currentHealth; } }

    [SerializeField] private double _maxHealth;
    [SerializeField] private double _demage;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Toggle _playerCanGetDamageToggle;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private TMP_Text _changeWeponbuttonText;
    [SerializeField] private LongRangeWepon _wepon;

    private double _currentHealth;

    // health regeneration variables. maybe need to make make new class later
    private double regenAmount = 1; 
    private float _timeToStartRegeneration = 5f, _regenerationInterval = 1f; 
    private Coroutine _regenerationCoroutine;

    private Color _hitColor = new Color(0.92f, 0.45f, 0.48f);
    private GameOverHandler _gameOverHanler;

    private static bool _isMeleeMode;

    public void Start()
    {
        _isMeleeMode = true;
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
        if (_isMeleeMode) PlayerAttack?.Invoke(_demage);
        else
        {
            if (EnemyList.Enemies.Count == 0) _wepon.OnFire(new Vector2(1, 0));
            else
            {
                _wepon.OnFire(transform.position);
            }
        }
    }

    public void ChangeWepon()
    {
        _isMeleeMode = !_isMeleeMode;
        if (_isMeleeMode)
        {
            _wepon.gameObject.SetActive(false);
            _changeWeponbuttonText.text = "melee";
        }
        else
        {
            _wepon.gameObject.SetActive(true);
            _changeWeponbuttonText.text = "gun";
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

    private Vector2 FindNearestEnemy()
    {
        return new Vector2();
    }
}
