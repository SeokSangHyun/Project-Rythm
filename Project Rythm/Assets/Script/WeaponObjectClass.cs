using UnityEngine;

public class WeaponObjectClass : WeaponClass , IRythmClass
{
    // IRythmClass 인터페이스 변수  
    public int StartBeat       { get; private set; } = 0;
    public int BeatTimming     { get; private set; } = 0;
    public int BeatCoolTime    { get; private set; } = 0;

    public int RailIndex       { get; private set; } = 0;


    //--------------------------------------------------
    // 초기화 함수
    //--------------------------------------------------
    public override void Init(EnumWeapon _e)
    {
        base.Init(_e);
    }



    //--------------------------------------------------
    // IRythmClass 인터페이스 함수 정의
    //--------------------------------------------------
    public void Beat(int beatCount)
    {
        // ??? ???? ??? ? ?? ??
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
