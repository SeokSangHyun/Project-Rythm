using UnityEngine;

public class WeaponObjectClass : WeaponClass , IRythmClass
{
    // IRythmClass �������̽� ����  
    public int StartBeat       { get; private set; } = 0;
    public int BeatTimming     { get; private set; } = 0;
    public int BeatCoolTime    { get; private set; } = 0;

    public int RailIndex       { get; private set; } = 0;


    //--------------------------------------------------
    // �ʱ�ȭ �Լ�
    //--------------------------------------------------
    public override void Init(EnumWeapon _e)
    {
        base.Init(_e);
    }



    //--------------------------------------------------
    // IRythmClass �������̽� �Լ� ����
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
    // IWeaponClass �������̽� �Լ� ����
    //--------------------------------------------------
    public void Damage()
    {

    }
}
