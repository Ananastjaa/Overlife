using UnityEngine;

public class LRWeaponObject : MonoBehaviour
{
    public WeaponGeneralData GeneralData { get { return _generalData; } }
    public WeaponCurrentData CurrentData { get { return _currentData; } }

    private WeaponCurrentData _currentData;
    private WeaponGeneralData _generalData;

    public void Init(string weaponID)
    {
        _currentData = WeaponDataDicts.WeaponCurDataDict[weaponID];
        _generalData = WeaponDataDicts.WeaponGenDataDict[weaponID];
    }
}
