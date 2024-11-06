using UnityEngine;

//--------------------------------------------------
// 빈 노드의 액션 클래스
//--------------------------------------------------
public class OnlyBeatClass : MonoBehaviour, IActionClass
{
    public GameObject prefabNode { get; private set; } = Resources.Load<GameObject>("Prefab/prefab_BeatNode_Arrow");
    public GameObject prefabObj { get; private set; } = null;

    public NodeType m_nodeType { get; private set; } = NodeType.OnlyBeat;

    public void CreateNode(int icount)      // 비트 노드 생성 매서드
    {
        GameObject obj = Instantiate(prefabNode);
        obj.name = prefabNode.name + "_" + icount;
    }

    public void OnClickEvent()    // 버튼 클릭 시 매서드
    {
        // 해당 클래스는 버튼 입력 없음
    }


    public void ActionEvent()     // 조건 만족했을 때 행동 발동 매서드
    {
        // 해당 클래스는 공격 없음
    }

}