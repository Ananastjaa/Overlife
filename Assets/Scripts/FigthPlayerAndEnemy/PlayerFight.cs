using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Collections;

public class PlayerFight : MonoBehaviour
{
    public static Action<double> PlayerAttack;
    public double Health { get { return _health; } }

    [SerializeField] private double _health;
    [SerializeField] private bool _playerCanGetDamage = true;
    [SerializeField] private double _demage;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Color _hitColor = new Color(0.92f, 0.45f, 0.48f);

    public void GetDemage(double demage){

        if (_playerCanGetDamage) {
            //_health -= demage;
            StartCoroutine(MakePlayeRedForAMoment());
            //Debug.Log("player health: " + _health);

            if (_health <= 0)
            {
                Destroy(transform.parent.gameObject);
            }
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
}