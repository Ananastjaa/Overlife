using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EnemyFight : MonoBehaviour
{
    // !!DEVIDES THIS CLASS!!
    [SerializeField] private double _maxHealth;
    [SerializeField] private double _demage;
    [SerializeField] private HealthBar _healthBar;

    private EnemyDieScript _dieScript;
    private double _health;
    private PlayerHealth _playerHealthScript;
    private bool _isInDemageZone = false;

    private void Start()
    {
        _dieScript = GetComponent<EnemyDieScript>();
        _health = _maxHealth;
        _playerHealthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        
    }

    private void OnEnable()
    {
        PlayerAttack.PlayerAttacked += GetDemage;
        EnemyList.Enemies.Add(transform);
    }

    private void OnDisable()
    {
        PlayerAttack.PlayerAttacked -= GetDemage;
        EnemyList.Enemies.Remove(transform);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isInDemageZone = true;
            StartCoroutine(Attack(_playerHealthScript));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isInDemageZone = false;
        }
    }

    public void GetDemage(double demage)
    {
        if (!PlayerAttack.IsMeleeMode || _isInDemageZone)
        {
            _health -= demage;
            _healthBar.SetHealthBar(_health, _maxHealth);

            if (_health <= 0) _dieScript.EnemyDie();
        }
    }

    private IEnumerator Attack(PlayerHealth player)
    {
        while (_isInDemageZone && !player.IsDestroyed())
        {
            player.GetDemage(_demage);
            yield return new WaitForSeconds(1);
        }
    }
}