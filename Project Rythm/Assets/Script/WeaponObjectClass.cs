using UnityEngine;

public class WeaponObjectClass : WeaponClass , IRythmClass
{
    //WeaponClass
    [SerializeField] private GameObject override_objNode;
    [SerializeField] private GameObject override_objWeapon;
    
    
    // IRythmClass ??
    public int StartBeat       { get; private set; } = 0;
    public int BeatTimming     { get; private set; } = 0;
    public int BeatCoolTime    { get; private set; } = 0;

    public int RailIndex       { get; private set; } = 0;


    //--------------------------------------------------
    // Awake
    //--------------------------------------------------
    private void Awake()
    {
        base.objNode = override_objNode;
        base.objWeapon = override_objWeapon;
    }
    
    
    //--------------------------------------------------
    // Init
    //--------------------------------------------------
    public override void Init(EnumWeapon _e)
    {
        base.Init(_e);
    }



    //--------------------------------------------------
    // IRythmClass ????? ?? ??
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
    // IWeaponClass ????? ?? ??
    //--------------------------------------------------
    public void Damage()
    {

    }
}
