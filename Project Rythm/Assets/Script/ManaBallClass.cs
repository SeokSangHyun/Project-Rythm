//--------------------------------------------------
// 무기 전체의 기능을 가진 Weapon Interface
//--------------------------------------------------
using UnityEngine;

public class ManaBallClass : MonoBehaviour, IActionClass
{
    public GameObject prefabNode { get; private set; } = Resources.Load<GameObject>("Prefab/prefab_Node_1");
    public GameObject prefabObj { get; private set; } = null;

    public NodeType m_nodeType { get; private set; } = NodeType.Normal;

    public void CreateNode(int icount)      // 비트 노드 생성 매서드
    {
        GameObject obj = Instantiate(prefabNode);
        obj.name = prefabNode.name + "_" + icount;
    }

    public void OnClickEvent()    // 버튼 클릭 시 매서드
    {

    }


    public void ActionEvent()     // 조건 만족했을 때 행동 발동 매서드
    {

    }

}