using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public List<LRWeaponObject> LRWeaponList { get { return _lrWeaponList; } }
    private LRWeaponObject SelectedLRWeapon { get { return _selectedLRWeapon; } }

    private List<LRWeaponObject> _lrWeaponList = new List<LRWeaponObject>();
    private LRWeaponObject _selectedLRWeapon;

    private List<string> _weponIDList = new List<string>();
    private TxtFileReader _reader = new TxtFileReader();

    private void Start()  // that need to bee called only once when app started to work
    {
        SetWeaponList();
        _selectedLRWeapon = _lrWeaponList[0];
    }

    private void SetWeaponList()
    {
        _weponIDList = _reader.GetFileContent(Paths.WeaponIDListTxt);

        foreach(string weaponID in _weponIDList)
        {
            _lrWeaponList.Add(new LRWeaponObject(weaponID));
        }
    }
}
