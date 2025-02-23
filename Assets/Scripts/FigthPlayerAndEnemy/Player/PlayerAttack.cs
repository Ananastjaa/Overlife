using UnityEngine;
using System;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    public static Action<double> PlayerAttacked;                  // need to delete this, made knife object, and hit enemies with it (OnTrigerEnter)
    public static bool IsMeleeMode { get { return _isMeleeMode; } }    // made that dinamic variable do not be amateur!!
    
    [SerializeField] private TMP_Text _selectedFightModeButtonText;

    private static bool _isMeleeMode;
    private PlayerStats _playerStats;

    public void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _isMeleeMode = _selectedFightModeButtonText.text == "melee";
    }

    public void Attack()
    {
        if (_isMeleeMode) PlayerAttacked?.Invoke(_playerStats.DemageMelee);
        else _playerStats.LongRangeWepon.OnFire(new Vector2(1, 0));
    }

    public void ChangeWepon()
    {
        _isMeleeMode = !_isMeleeMode;
        if (_isMeleeMode)
        {
            _playerStats.LongRangeWepon.gameObject.SetActive(false);
            _selectedFightModeButtonText.text = "melee";
        }
        else
        {
            _playerStats.LongRangeWepon.gameObject.SetActive(true);
            _selectedFightModeButtonText.text = "gun";
        }
    }
}
