

using UnityEngine;

//--------------------------------------------------
// ���� ��ü�� ����� ���� Weapon Interface
//--------------------------------------------------
public interface INodeActionClass
{
    //��� �� ����
    NodeType nodeType { get; }
    int RailIndex { get; }          // 0�̸� ��� Rail���� ����
    int BeatTimming { get; }        // 1�̸� �� ��Ʈ���� ���
    int Maintain { get; }           // 0�̸� ��ġ���ϴ� ���
    int CoolTime { get; }           // 0�̸� �� ��Ʈ ���

    void OnClickEvent();    // ��ư Ŭ�� �� �ż���
    void AttackEvent();     // ���� �������� �� �ൿ �ߵ� �ż���

}


// �����ؼ� ���ߴ� ��� -> ���� ī��Ʈ�� �ذ��ؾ���
// �Ѱ��� ���ߴ� ��� -> Ŭ������ �ذ��
// �� ������ �ִ� ��� -> Ŭ���� �� ���� ���� �ذ��

