

using UnityEngine;

//--------------------------------------------------
// 무기 전체의 기능을 가진 Weapon Interface
//--------------------------------------------------
public interface IActionClass
{
    GameObject prefabNode { get; }
    GameObject prefabObj { get; }

    NodeType m_nodeType { get; }

    void CreateNode(int icount);      // 비트 노드 생성 매서드
    void OnClickEvent();    // 버튼 클릭 시 매서드
    void ActionEvent();     // 조건 만족했을 때 행동 발동 매서드

}


// 연속해서 맞추는 경우 -> 누적 카운트로 해결해야함
// 한개만 맞추는 경우 -> 클릭으로 해결됨
// 쭉 누르고 있는 경우 -> 클릭으 후 땠을 때로 해결됨

