using Unity.VisualScripting;
using UnityEngine;
using System;

public class PlayerFight : MonoBehaviour
{
    // sdelatj pole bool dla vragov i menatj jego elsi vrag nahoditsa v zode ataki
    // nazav knopku aktivirovatj sobitije
    // krasnij vrag kogda ego bjut

    public static Action<double> PlayerAttack;
    public double Health { get { return _health; } }

    [SerializeField] private double _health;
    [SerializeField] private double _demage;

    public void GetDemage(double demage)
    {
        _health -= demage;
        Debug.Log("player health: " + _health);

        if (_health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    public void Attack()
    {
        PlayerAttack?.Invoke(_demage);
    }
}