using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _desription;
    [SerializeField] private TMP_Text _weaponName;
    [SerializeField] private Button _buyBut;

    private WeaponCurrentData _currentData;
    private WeaponGeneralData _generalData;
    private UpgradePanel _upgradePanel;

    public void SetDescription(LRWeaponObject weapon, UpgradePanel upgradePanle)
    {
        _upgradePanel = upgradePanle;
        _generalData = weapon.GeneralData;
        _currentData = weapon.CurrentData;
        _desription.text = $"price : {_generalData.Price}\nstart demage : {_generalData.StartDemage}\nmax demage : {_generalData.MaxDemage}";
        _weaponName.text = _generalData.WeaponID.ToString().ToUpper();
        _buyBut.GetComponentInChildren<TMP_Text>().text = _generalData.Price.ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void BuyWeapon()
    {
        _currentData.IsBought = true;
        _currentData.IsSelected = false;

        _upgradePanel.Show();
        Hide();
    }
}
