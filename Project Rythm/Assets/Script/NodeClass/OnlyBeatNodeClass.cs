using UnityEngine;

//--------------------------------------------------
// �� ����� �׼� Ŭ����
//--------------------------------------------------
public class OnlyBeatNodeClass : MonoBehaviour, INodeActionClass
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

    // ��� ����
    public void CreateBeatNode(int accCount)
    {


        //GameObject obj = Instantiate(WeaponList.GetBeatNode( gameObject.NodeType nodeType));
        //obj.name = obj.name + iNodeCount;


        //++iNodeCount;
    }


    // ��ư Ŭ�� �� �ż���
    public void OnClickEvent()
    {
        // �ش� Ŭ������ ��ư �Է� ����
    }


    // ���� �������� �� �ൿ �ߵ� �ż���
    public void AttackEvent()
    {
        print("OnlyBeat Node");

        // �ش� Ŭ������ ���� ����
    }

}