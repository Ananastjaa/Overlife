using UnityEngine;

public class Paths : MonoBehaviour
{
    public static string WeaponIDListTxt { get { return _weaponListTxt; } }
    public static string WeaponCurDataJson { get { return _weaponCurDataJson; } }
    public static string WeaponGenDataJson { get { return _weaponGenDataJson; } }

    private static string _weaponListTxt = "Assets/RegistryFiles/WeaponList.txt";
    private static string _weaponCurDataJson = "Assets/RegistryFiles/WeaponsCurrentData.json";
    private static string _weaponGenDataJson = "Assets/RegistryFiles/WeaponsGeneralData.json";
}
