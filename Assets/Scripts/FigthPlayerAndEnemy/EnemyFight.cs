using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] private double _health;
    [SerializeField] private double _demage;

    private PlayerFight _player;
    private bool _isInDemageZone = false;
    private bool _needToDestroy;

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
            Debug.Log("Stop kill");
        }
    }

    public void GetDemage(double demage)
    {
        if (_isInDemageZone)
        {
            _health -= demage;
            Debug.Log("enemy health: " + _health);

            if (_health <= 0) Destroy(this.gameObject);
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