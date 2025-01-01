using UnityEngine;

public class WeaponObjectClass : MonoBehaviour, IRythmClass , IWeaponClass
{
    // IRythmClass 인터페이스 변수
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


    // IWeaponClass 인터페이스 변수
    public EnumWeapon eWeapon { get; private set; } = EnumWeapon.Test;


    //--------------------------------------------------
    // IRythmClass 인터페이스 함수 정의
    //--------------------------------------------------
    public void Beat(int beatCount)
    {
        // 생성 시점에서 노드 생성하기
        if ((beatCount % BeatTimming) == 0)
        {
            GameObject obj = Instantiate(StaticWeaponList.GetBeatNode(eWeapon));
            obj.name = obj.name + StaticVariable.iNodeCount;
            obj.transform.GetComponent<csNodeControl>().Init(RailIndex);

            StaticVariable.NodeCounting();
        }
    }



    //--------------------------------------------------
    // IWeaponClass 인터페이스 함수 정의
    //--------------------------------------------------
    public void Damage()
    {

    }
}
