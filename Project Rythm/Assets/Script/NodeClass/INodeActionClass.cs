

using UnityEngine;

//--------------------------------------------------
// 무기 전체의 기능을 가진 Weapon Interface
//--------------------------------------------------
public interface INodeActionClass
{
    //노드 용 변수
    NodeType nodeType { get; }
    int RailIndex { get; }          // 0이면 모든 Rail에서 나옴
    int BeatTimming { get; }        // 1이면 매 비트마다 출력
    int Maintain { get; }           // 0이면 터치만하는 노드
    int CoolTime { get; }           // 0이면 매 비트 출력

    void OnClickEvent();    // 버튼 클릭 시 매서드
    void AttackEvent();     // 조건 만족했을 때 행동 발동 매서드

}


// 연속해서 맞추는 경우 -> 누적 카운트로 해결해야함
// 한개만 맞추는 경우 -> 클릭으로 해결됨
// 쭉 누르고 있는 경우 -> 클릭으 후 땠을 때로 해결됨

