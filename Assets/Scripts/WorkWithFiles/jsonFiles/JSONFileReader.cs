using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class JSONFileReader : MonoBehaviour
{
    public static Dictionary<string, WeaponCurrentData> WeaponCurDataDict { get { return _weaponCurDataDict; } }
    public static Dictionary<string, WeaponGeneralData> WeaponGenDataDict { get { return _weaponGenDataDict; } }

    private StreamReader _reader;

    private static Dictionary<string, WeaponCurrentData> _weaponCurDataDict = new();
    private static Dictionary<string, WeaponGeneralData> _weaponGenDataDict = new();

    private List<WeaponCurrentData> _weaponCurDataList;
    private List<WeaponGeneralData> _weaponGenDataList;

    private string _json;

    private void Start() // that need to bee called only once when app started to work
    {
        SetWeapCureDataList();
        SetWeapGenDataList();
    }

    private void SetWeapCureDataList()
    {
        _weaponCurDataList = new List<WeaponCurrentData>();

        _reader = new StreamReader(Paths.WeaponCurDataJson);

        while (!_reader.EndOfStream)
        {
            _json = _reader.ReadLine();
            if (_json != null)
            {
                WeaponCurrentData temp = JsonUtility.FromJson<WeaponCurrentData>(_json);
                _weaponCurDataList.Add(temp);
            }
        }

        _reader.Close();

        foreach (WeaponCurrentData weopData in _weaponCurDataList)
        {
            _weaponCurDataDict[weopData.WeaponID] = weopData;
        }
    }

    private void SetWeapGenDataList()
    {
        _weaponGenDataList = new List<WeaponGeneralData>();

        _reader = new StreamReader(Paths.WeaponGenDataJson);

        while(!_reader.EndOfStream)
        {
            _json = _reader.ReadLine();
            if (_json != null)
            {
                WeaponGeneralData temp = JsonUtility.FromJson<WeaponGeneralData>(_json);
                _weaponGenDataList.Add(temp);
            }
        }

        _reader.Close();

        foreach (WeaponGeneralData weopData in _weaponGenDataList)
        {
            _weaponGenDataDict[weopData.WeaponID] = weopData;
        }
    }

    //private void PrintDictionaries()
    //{
    //    foreach(var key in _weaponCurDataDict.Keys)
    //    {
    //        var a = _weaponCurDataDict[key].Demage;
    //        var b = _weaponCurDataDict[key].IsBought;
    //        Debug.Log($"{key} ---> dem:{a}, isBought:{b}");
    //    }

    //    foreach (var key in _weaponGenDataDict.Keys)
    //    {
    //        var a = _weaponGenDataDict[key].Price;
    //        var b = _weaponGenDataDict[key].MaxDemage;
    //        Debug.Log($"{key} ---> price:{a}, MaxDem:{b}");
    //    }
    //}


    //public void WriteData()
    //{
    //    string jsonString = "";
    //    _weaponGenDataList = new List<WeaponGeneralData>();

    //    var temp = new WeaponGeneralData() { Price = 10, StartDemage = 3.5f, MaxDemage = 5f, WeaponID = "weopon1" };
    //    _weaponGenDataList.Add(temp);
    //    temp = new WeaponGeneralData() { Price = 300, StartDemage = 1.5f, MaxDemage = 7f, WeaponID = "weopon2" };
    //    _weaponGenDataList.Add(temp);

    //    StreamWriter _wreader = new StreamWriter(Paths.WeaponGenDataJson);
    //    foreach(var obj in _weaponGenDataList)
    //    {
    //        jsonString += JsonUtility.ToJson(obj) + "\n";
    //    }    

    //    _wreader.WriteLine(jsonString);
    //    _wreader.Close();

    //    string jsonString2 = "";
    //    _weaponCurDataList = new List<WeaponCurrentData>();

    //    var temp2 = new WeaponCurrentData();
    //    temp2 = new WeaponCurrentData() { Demage = 1, IsBought = false, IsSelected = true, WeaponID = "weopon1" };
    //    _weaponCurDataList.Add(temp2);
    //    temp2 = new WeaponCurrentData() { Demage = 2, IsBought = false, IsSelected = false, WeaponID = "weopon2" };
    //    _weaponCurDataList.Add(temp2);

    //    StreamWriter _wreader2 = new StreamWriter(Paths.WeaponCurDataJson);
    //    foreach (var obj in _weaponCurDataList)
    //    {
    //        jsonString2 += JsonUtility.ToJson(obj) + "\n";
    //    }


    //    _wreader2.WriteLine(jsonString2);
    //    _wreader2.Close();
    //}
}