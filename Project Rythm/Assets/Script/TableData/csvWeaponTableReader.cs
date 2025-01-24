using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;



public class csvWeaponTableReader : MonoBehaviour
{
    private string table_name = "WeaponTable";
    
    // CSV 파일 경로
    public string filePath = "Assets/Resources/TableData/WeaponTable.csv";

    void Start()
    {
        List<string[]> data = ReadCSV(filePath);

        foreach (var row in data)
        {
            Debug.Log(string.Join(", ", row)); // CSV 내용을 출력
        }
    }

    List<string[]> ReadCSV(string path)
    {
        List<string[]> csvData = new List<string[]>();

        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // 각 줄을 콤마로 분리하여 배열로 저장
                    string[] values = line.Split(',');
                    csvData.Add(values);
                }
            }
        }
        catch (Exception e)
        {
              Debug.LogError($"Error reading CSV file: {e.Message}");
        }

        return csvData;
    }
}
