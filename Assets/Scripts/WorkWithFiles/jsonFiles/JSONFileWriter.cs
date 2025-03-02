using System.IO;
using UnityEngine;

public class JSONFileWriter : MonoBehaviour
{
    private StreamWriter _writer;
    private string _json;
    private void OnEnable()
    {
        Weapons.SelectedWeaponChanged += UpdateFileData;
    }

    private void OnDisable()
    {
        Weapons.SelectedWeaponChanged -= UpdateFileData;
    }

    private void UpdateFileData()
    {
        _writer = new StreamWriter(Paths.WeaponCurDataJson);

        foreach (var weaponData in WeaponDataDicts.WeaponCurDataDict.Values)
        {
            _json = JsonUtility.ToJson(weaponData);
            _writer.WriteLine(_json);
        }

        _writer.Close();
    }
}
