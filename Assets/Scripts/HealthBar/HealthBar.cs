using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _healthBar;
    void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.value = 1;
    }

    public void SetHealthBar(double currentHealth, double maxHealth)
    {
        _healthBar.value = Convert.ToSingle(currentHealth / maxHealth);
    }
}
