using UnityEngine;

//--------------------------------------------------
// �� ����� �׼� Ŭ����
//--------------------------------------------------
public class OnlyBeatClass : MonoBehaviour, IActionClass
{
    public GameObject prefabNode { get; private set; } = Resources.Load<GameObject>("Prefab/prefab_BeatNode_Arrow");
    public GameObject prefabObj { get; private set; } = null;

    public NodeType m_nodeType { get; private set; } = NodeType.OnlyBeat;

    public void CreateNode(int icount)      // ��Ʈ ��� ���� �ż���
    {
        GameObject obj = Instantiate(prefabNode);
        obj.name = prefabNode.name + "_" + icount;
    }

    public void OnClickEvent()    // ��ư Ŭ�� �� �ż���
    {
        // �ش� Ŭ������ ��ư �Է� ����
    }


    public void ActionEvent()     // ���� �������� �� �ൿ �ߵ� �ż���
    {
        // �ش� Ŭ������ ���� ����
    }

}