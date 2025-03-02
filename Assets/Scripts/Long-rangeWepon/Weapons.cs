using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapons : MonoBehaviour
{
    public static Action SelectedWeaponChanged;

    public static Dictionary<string, LRWeaponObject> LRWeaponDict { get { return _lrWeaponDict; } }
    public static LRWeaponObject SelectedLRWeapon { get { return _selectedLRWeapon; } }

    private static Dictionary<string, LRWeaponObject> _lrWeaponDict = new Dictionary<string, LRWeaponObject>();
    private static LRWeaponObject _selectedLRWeapon;

    private static List<string> _weponIDList = new();
    private static TxtFileReader _reader;

    private void OnEnable()
    {
        UpgradePanel.WeaponChanged += ChangeSelectedWeapom;
    }

    private void OnDisable()
    {
        UpgradePanel.WeaponChanged -= ChangeSelectedWeapom;
    }

    private void Start()  // that need to bee called only once when app started to work
    {
        // nado eto kakto povmenajemeje sdelatj
        //--
        JSONFileReader _jsonReader = gameObject.AddComponent<JSONFileReader>();
        _jsonReader.SetWeapCureDataDict();
        _jsonReader.SetWeapGenDataDict();
        //--
  
        _reader = gameObject.AddComponent<TxtFileReader>();
        SetWeaponList();
        foreach(var weapon in _lrWeaponDict.Values)
        {
            if (weapon.CurrentData.IsSelected)
            {
                _selectedLRWeapon = weapon;
                break;
            }
        }
    }

    private void SetWeaponList()
    {
        _weponIDList = _reader.GetFileContent(Paths.WeaponIDListTxt);

        foreach(string weaponID in _weponIDList)
        {
            _lrWeaponDict[weaponID] = gameObject.AddComponent<LRWeaponObject>();
            _lrWeaponDict[weaponID].Init(weaponID);
        }
    }

    public void ChangeSelectedWeapom(string weaponID)
    {
        _selectedLRWeapon.CurrentData.IsSelected = false;
        _selectedLRWeapon = _lrWeaponDict[(weaponID)];
        SelectedWeaponChanged?.Invoke();
    }
}
