using UnityEngine;


//--------------------------------------------------
// 장비의 리듬에 대한 Interface Class
//--------------------------------------------------
public interface IRythmClass
{
    //노드 용 변수
    NodeType nodeType { get; }
    int StartBeat { get; }          // 비트 시작 시점
    int BeatTimming { get; }        // 비트 나오는 타이밍 (ex. 1이면 매 비트마다 출력)
    int BeatCoolTime { get; }       // 노드가 나오고 다음 기다리는 시간

    int RailIndex { get; }          // 노드가 레일에 나오는 위치 (0이면 모든 Rail에서 나옴)

    void Beat(int beatCount);       //비트 체크
}
