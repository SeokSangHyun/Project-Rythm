using UnityEngine;

//--------------------------------------------------
// �� ����� �׼� Ŭ����
//--------------------------------------------------
public class TestNodeClass : MonoBehaviour, INodeActionClass
{
    [SerializeField]
    private NodeType _nodeType;
    public NodeType nodeType
    {
        get => _nodeType;
        set => _nodeType = value;
    }

    public int RailIndex { get; private set; } = 0;
    public int BeatTimming { get; private set; } = 1;
    public int Maintain { get; private set; } = 0;
    public int CoolTime { get; private set; } = 0;

    public void OnClickEvent()    // ��ư Ŭ�� �� �ż���
    {
        // �ش� Ŭ������ ��ư �Է� ����
    }


    public void AttackEvent()     // ���� �������� �� �ൿ �ߵ� �ż���
    {
        print("OnlyBeat Node");

        // �ش� Ŭ������ ���� ����
    }

}