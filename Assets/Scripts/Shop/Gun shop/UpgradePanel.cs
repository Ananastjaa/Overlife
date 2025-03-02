using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    public static Action<string> WeaponChanged;

    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _weaponName;
    [SerializeField] private Button _selectBut;

    private static UpgradePanel _selectedWeponUpgradePanel;

    private TMP_Text _selectedButtText;
    private string _weoponId;

    public void SetDescription(WeaponCurrentData curData)
    {
        _weaponName.text = curData.WeaponID.ToString().ToUpper();

        _weoponId = curData.WeaponID;
        _selectedButtText = _selectBut.GetComponentInChildren<TMP_Text>();

        if (curData.IsSelected)
        {
            _selectedButtText.text = "Selected";
            _selectBut.enabled = false;
            _selectedWeponUpgradePanel = this;
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void SelectWeapon()
    {
        _selectedWeponUpgradePanel._selectedButtText.text = "select";
        _selectedWeponUpgradePanel._selectBut.enabled = true;
        _selectedWeponUpgradePanel = this;

        WeaponDataDicts.WeaponCurDataDict[_weoponId].IsSelected = true;
        _selectBut.enabled = false;
        _selectBut.GetComponentInChildren<TMP_Text>().text = "Selected";
        WeaponChanged?.Invoke(_weoponId);
    }
}
