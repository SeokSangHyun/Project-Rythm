using System.Collections.Generic;
using UnityEngine;

public class cs_MusicPlayManager : MonoBehaviour
{
    private List<cs_MusicBar> list_Bar = new List<cs_MusicBar>();


    //---------- ---------- ---------- ---------- ----------
    private void Start()
    {
        list_Bar.Add( new cs_MusicBar() );

        foreach (cs_MusicBar bar in list_Bar)
        {
            bar.CreateBar();
        }
    }
}
