using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeaponShopItem : MonoBehaviour
{
    public static Action<string> WeaponChanged;

//NOT DONE YET
    [SerializeField] private GameObject _lockPicture;
    [SerializeField] private GameObject _byPanle;
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private TMP_Text _desription;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _upgradeDesription;
    [SerializeField] private TMP_Text _upgradName;
    [SerializeField] private Button _selectBut;
    [SerializeField] private Button _byBut;

    private WeaponGeneralData _generalData;
    private WeaponCurrentData _currentData;
    private string _weoponId;

    public void Init(LRWeaponObject weapon)
    {
        SetDescription(weapon);
        SetOtherDetails(weapon);
    }

    private void SetDescription(LRWeaponObject weapon)
    {
        _generalData = weapon.WeaponGeneralData;
        _desription.text = $"price : {_generalData.Price}\nstart demage : {_generalData.StartDemage}\nmax demage : {_generalData.MaxDemage}";
        _name.text = _generalData.WeaponID.ToString().ToUpper();
        _upgradName.text = _generalData.WeaponID.ToString().ToUpper();

        _byBut.GetComponentInChildren<TMP_Text>().text = _generalData.Price.ToString();
        _weoponId = _generalData.WeaponID;
    }

    private void SetOtherDetails(LRWeaponObject weapon)
    {
        _currentData = weapon.WeaponCurrentData;
        if (_currentData.IsBought)
        {
            _lockPicture.SetActive(false);
            _byPanle.SetActive(false);
            _upgradePanel.SetActive(true);
        }
        else
        {
            _lockPicture.SetActive(true);
            _byPanle.SetActive(true);
            _upgradePanel.SetActive(false);
        }

        if (_currentData.IsSelected)
        {
            _selectBut.enabled = false;
            _selectBut.GetComponentInChildren<TMP_Text>().text = "Selected";
        }
    }

    public void ByWeapon()
    {
        _currentData.IsBought = true;
        _currentData.IsSelected = false;

        // copy past     ne horoshoooooooo
        Debug.Log("KUPILA AAAAAAA");
        _lockPicture.SetActive(false);
        _byPanle.SetActive(false);
        _upgradePanel.SetActive(true);
        _selectBut.enabled = true;
        _selectBut.GetComponentInChildren<TMP_Text>().text = "Select";
    }

    // ne rabotajet kak nadoooo         knopka ne stanovts ne aktivno, json fle ne vsegda obnovlajetsa
    public void SelectWeapon()
    {
        _currentData.IsSelected = true;
        _selectBut.enabled = false;
        _selectBut.GetComponentInChildren<TMP_Text>().text = "Selected";
        WeaponChanged?.Invoke(_weoponId);
    }


}
