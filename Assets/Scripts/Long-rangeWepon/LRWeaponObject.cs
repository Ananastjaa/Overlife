using UnityEngine;

public class LRWeaponObject : MonoBehaviour
{
    public WeaponGeneralData WeaponGeneralData { get { return _weaponGeneralData; } }
    public WeaponCurrentData WeaponCurrentData { get { return _weaponCurrentData; } }

    private WeaponCurrentData _weaponCurrentData;
    private WeaponGeneralData _weaponGeneralData;

    //public LRWeaponObject(string weaponID)
    //{
    //    _weaponCurrentData = JSONFileReader.WeaponCurDataDict[weaponID];
    //    _weaponGeneralData = JSONFileReader.WeaponGenDataDict[weaponID];
    //}

    public void Init(string weaponID)
    {
        _weaponCurrentData = JSONFileReader.WeaponCurDataDict[weaponID];
        _weaponGeneralData = JSONFileReader.WeaponGenDataDict[weaponID];
    }
}
