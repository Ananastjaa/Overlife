using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TxtFileReader : MonoBehaviour
{
    private StreamReader _reader;
    private List<string> _fileContent = new List<string>();
    private string _line;

    public List<string> GetFileContent(string filePath)
    {
        _fileContent.Clear();
        _reader = new StreamReader(filePath);
        _line = _reader.ReadLine();

        while (!_reader.EndOfStream)
        {
            if (_line != null || _line != "")
            {
                _fileContent.Add(_line);
            }
        }

        _reader.Close();

        return _fileContent;
    }

    //public void Create()
    //{
    //    StreamWriter _writer = new StreamWriter(Paths.WeaponIDListTxt);
    //    _writer.WriteLine("aaaa");
    //    _writer.Close();
    //}
}
