using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;



public class csvMusicReader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //csvReader();
    }

    //void csvReader()
    //{
    //    StreamReader sr = new StreamReader(Application.dataPath + "/Resource/" + "music_name1_v1.txt");

    //    bool endOfFile = false;
    //    while (!endOfFile)
    //    {
    //        string data_String = sr.ReadLine();
    //        if (data_String == null)
    //        {
    //            endOfFile = true;
    //            break;
    //        }
    //        var data_values = data_String.Split('|');
    //        for (int i = 0; i < data_values.Length; i++)
    //        {
    //            //Debug.Log(data_values[i].ToString());
    //        }
    //    }
    //}


}
