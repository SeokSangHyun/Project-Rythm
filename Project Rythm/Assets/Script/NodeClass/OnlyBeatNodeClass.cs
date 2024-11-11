using UnityEngine;

//--------------------------------------------------
// 빈 노드의 액션 클래스
//--------------------------------------------------
public class OnlyBeatNodeClass : MonoBehaviour, INodeActionClass
{

    public void OnClickEvent()    // 버튼 클릭 시 매서드
    {
        // 해당 클래스는 버튼 입력 없음
    }


    public void AttackEvent()     // 조건 만족했을 때 행동 발동 매서드
    {
        print("OnlyBeat Node");

        // 해당 클래스는 공격 없음
    }

}