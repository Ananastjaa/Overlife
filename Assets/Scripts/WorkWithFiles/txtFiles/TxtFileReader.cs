using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TxtFileReader : MonoBehaviour
{
    private StreamReader _reader;
    private List<string> _fileContent;
    private string _line;

    public List<string> GetFileContent(string filePath)
    {
        _fileContent = new List<string>();
        _reader = new StreamReader(filePath);

        while (!_reader.EndOfStream)
        {
            _line = _reader.ReadLine();
            if (_line != null && _line != "")
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
