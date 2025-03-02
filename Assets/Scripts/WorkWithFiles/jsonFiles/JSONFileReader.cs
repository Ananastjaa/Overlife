using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class JSONFileReader : MonoBehaviour
{
    private StreamReader _reader;

    private static List<WeaponCurrentData> _weaponCurDataList;
    private static List<WeaponGeneralData> _weaponGenDataList;

    private string _json;

    public void SetWeapCureDataDict()
    {
        _weaponCurDataList = new List<WeaponCurrentData>();

        _reader = new StreamReader(Paths.WeaponCurDataJson);

        while (!_reader.EndOfStream)
        {
            _json = _reader.ReadLine();
            if (_json != null)
            {
                try
                {
                    WeaponCurrentData temp = JsonUtility.FromJson<WeaponCurrentData>(_json);
                    _weaponCurDataList.Add(temp);
                }
                catch (Exception ex)
                {
                    Debug.Log(ex.Message);
                }
            }
        }

        _reader.Close();

        foreach (WeaponCurrentData weopData in _weaponCurDataList)
        {
            WeaponDataDicts.WeaponCurDataDict[weopData.WeaponID] = weopData;
        }
    }

    public void SetWeapGenDataDict()
    {
        _weaponGenDataList = new List<WeaponGeneralData>();

        _reader = new StreamReader(Paths.WeaponGenDataJson);

        while(!_reader.EndOfStream)
        {
            _json = _reader.ReadLine();
            if (_json != null)
            {
                try
                {
                    WeaponGeneralData temp = JsonUtility.FromJson<WeaponGeneralData>(_json);
                    _weaponGenDataList.Add(temp);
                }
                catch (Exception ex)
                {
                    Debug.Log(ex.Message);
                }
            }
        }

        _reader.Close();

        foreach (WeaponGeneralData weopData in _weaponGenDataList)
        {
            WeaponDataDicts.WeaponGenDataDict[weopData.WeaponID] = weopData;
        }
    }

    //     MAY BE USEFUL LATER

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