using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;
using UnityEngine.UI;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] private double _maxHealth;
    [SerializeField] private double _demage;
    [SerializeField] private Slider _healthBar;

    private EnemyDieScript _dieScript;
    private double _health;
    private PlayerFight _player;
    private bool _isInDemageZone = false;
    private bool _needToDestroy;

    private void Start()
    {
        _dieScript = GetComponent<EnemyDieScript>();
        _health = _maxHealth;
    }

    private void OnEnable()
    {
        PlayerFight.PlayerAttack += GetDemage;
    }

    private void OnDisable()
    {
        PlayerFight.PlayerAttack -= GetDemage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isInDemageZone = true;
            _player = other.gameObject.GetComponent<PlayerFight>();
            StartCoroutine(Attack(_player));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isInDemageZone = false;
            _player = other.gameObject.GetComponent<PlayerFight>();
        }
    }

    public void GetDemage(double demage)
    {
        if (_isInDemageZone)
        {
            _health -= demage;
            _healthBar.value = Convert.ToSingle(_health / _maxHealth);

            if (_health <= 0) _dieScript.EnemyDie();
        }
    }

    private IEnumerator Attack(PlayerFight player)
    {
        while (_isInDemageZone && !player.IsDestroyed())
        {
            player.GetDemage(_demage);
            yield return new WaitForSeconds(1);
        }
    }
}