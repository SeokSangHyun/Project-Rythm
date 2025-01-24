using UnityEngine;


public enum BeatType
{
    Dot,                //o
    Double,             //oo
    Strait_2,           //o-
    Strait_5,           //o----
}


//--------------------------------------------------
// 장비의 리듬에 대한 Interface Class
//--------------------------------------------------
public interface IRythmClass
{
    bool[] m_beats { get; set; }
    BeatType m_beattype  { get; }         // 비트의 타입 0번 이면 1개짜리
    
    //--------------------------------------------------
    // 함수 선언
    //--------------------------------------------------
    
    void Beat(int beatCount);       //비트 체크
}
