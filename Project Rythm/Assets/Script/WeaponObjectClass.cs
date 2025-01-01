using UnityEngine;

public class WeaponObjectClass : MonoBehaviour, IRythmClass , IWeaponClass
{
    // IRythmClass �������̽� ����
    [SerializeField]
    private NodeType _nodeType;
    public NodeType nodeType
    {
        get => _nodeType;
        set => _nodeType = value;
    }
    public int StartBeat       { get; private set; } = 0;
    public int BeatTimming     { get; private set; } = 0;
    public int BeatCoolTime    { get; private set; } = 0;

    public int RailIndex       { get; private set; } = 0;


    // IWeaponClass �������̽� ����
    public EnumWeapon eWeapon { get; private set; } = EnumWeapon.Test;


    //--------------------------------------------------
    // IRythmClass �������̽� �Լ� ����
    //--------------------------------------------------
    public void Beat(int beatCount)
    {
        // ���� �������� ��� �����ϱ�
        if ((beatCount % BeatTimming) == 0)
        {
            GameObject obj = Instantiate(StaticWeaponList.GetBeatNode(eWeapon));
            obj.name = obj.name + StaticVariable.iNodeCount;
            obj.transform.GetComponent<csNodeControl>().Init(RailIndex);

            StaticVariable.NodeCounting();
        }
    }



    //--------------------------------------------------
    // IWeaponClass �������̽� �Լ� ����
    //--------------------------------------------------
    public void Damage()
    {

    }
}
