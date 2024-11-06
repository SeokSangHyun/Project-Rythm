

using UnityEngine;

//--------------------------------------------------
// ���� ��ü�� ����� ���� Weapon Interface
//--------------------------------------------------
public interface IActionClass
{
    GameObject prefabNode { get; }
    GameObject prefabObj { get; }

    NodeType m_nodeType { get; }

    void CreateNode(int icount);      // ��Ʈ ��� ���� �ż���
    void OnClickEvent();    // ��ư Ŭ�� �� �ż���
    void ActionEvent();     // ���� �������� �� �ൿ �ߵ� �ż���

}


// �����ؼ� ���ߴ� ��� -> ���� ī��Ʈ�� �ذ��ؾ���
// �Ѱ��� ���ߴ� ��� -> Ŭ������ �ذ��
// �� ������ �ִ� ��� -> Ŭ���� �� ���� ���� �ذ��

