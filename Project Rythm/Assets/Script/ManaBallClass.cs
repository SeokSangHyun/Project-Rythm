//--------------------------------------------------
// ���� ��ü�� ����� ���� Weapon Interface
//--------------------------------------------------
using UnityEngine;

public class ManaBallClass : MonoBehaviour, IActionClass
{
    public GameObject prefabNode { get; private set; } = Resources.Load<GameObject>("Prefab/prefab_Node_1");
    public GameObject prefabObj { get; private set; } = null;

    public NodeType m_nodeType { get; private set; } = NodeType.Normal;

    public void CreateNode(int icount)      // ��Ʈ ��� ���� �ż���
    {
        GameObject obj = Instantiate(prefabNode);
        obj.name = prefabNode.name + "_" + icount;
    }

    public void OnClickEvent()    // ��ư Ŭ�� �� �ż���
    {

    }


    public void ActionEvent()     // ���� �������� �� �ൿ �ߵ� �ż���
    {

    }

}