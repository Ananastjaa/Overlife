using UnityEngine;

public class WeaponShopItem : MonoBehaviour
{
    [SerializeField] private BuyPanel _byPanel;
    [SerializeField] private UpgradePanel _upgradePanel;

    private WeaponGeneralData _generalData;
    private WeaponCurrentData _currentData;

    public void Init(LRWeaponObject weapon)
    {
        SetDescription(weapon);
        SetActiveRightElments(weapon);
    }

    private void SetDescription(LRWeaponObject weapon)
    {
        _generalData = weapon.GeneralData;
        _byPanel.SetDescription(weapon, _upgradePanel);
        _upgradePanel.SetDescription(weapon.CurrentData);
    }

    private void SetActiveRightElments(LRWeaponObject weapon)
    {
        _currentData = weapon.CurrentData;
        if (_currentData.IsBought)
        {
            _byPanel.Hide();
            _upgradePanel.Show();
        }
    }
}
