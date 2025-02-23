using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRWeaponObject : MonoBehaviour
{
    public WeaponGeneralData WeaponGeneralData { get { return _weaponGeneralData; } }
    public WeaponCurrentData WeaponCurrentData { get { return _weaponCurrentData; } }
    //public LongRangeWeapon LongRangeWeapon { get { return _longRangeWepon; } }

    private WeaponCurrentData _weaponCurrentData;
    private WeaponGeneralData _weaponGeneralData;
    //private LongRangeWeapon _longRangeWepon;

    public LRWeaponObject(string weaponID)
    {
        _weaponCurrentData = JSONFileReader.WeaponCurDataDict[weaponID];
        _weaponGeneralData = JSONFileReader.WeaponGenDataDict[weaponID];
    }
}
