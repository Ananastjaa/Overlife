using UnityEngine;

public class Paths : MonoBehaviour
{
    public static string WeaponIDListTxt { get { return _weaponListTxt; } }
    public static string WeaponCurDataJson { get { return _weaponCurDataJson; } }
    public static string WeaponGenDataJson { get { return _weaponGenDataJson; } }

    private readonly static string _weaponListTxt = "Assets/RegistryFiles/WeaponList.txt";
    private readonly static string _weaponCurDataJson = "Assets/RegistryFiles/WeaponsCurrentData.json";
    private readonly static string _weaponGenDataJson = "Assets/RegistryFiles/WeaponsGeneralData.json";
}
