using Unity.VisualScripting;
using UnityEngine;

public class WeaponObjectClass : WeaponClass , IRythmClass
{
    //WeaponClass
    [SerializeField] private EnumWeapon override_eWeapon;
    [SerializeField] private GameObject override_objNode;
    [SerializeField] private GameObject override_objWeapon;
    
    
    // IRythmClass ??
    public BeatType m_beattype        { get; private set; } = BeatType.Dot;
    public bool[]   m_beats           { get; set; }



    //--------------------------------------------------
    // Awake
    //--------------------------------------------------
    private void Awake()
    {
        base.eWeapon = override_eWeapon;
        base.objNode = override_objNode;
        base.objWeapon = override_objWeapon;

        NodeType nodetype = override_objNode.GetComponent<csNodeControl>().m_nodeType;
        switch (nodetype)
        {
            case NodeType.Test:
            case NodeType.Normal:
            case NodeType.OnlyBeat:
                m_beattype = BeatType.Dot;
                m_beats = new bool[] {true};
                break;
            default:
                break;
        }
        m_beattype = BeatType.Dot;
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
        if ((beatCount % 2) == 0)
        {
            // GameObject obj = Instantiate(StaticWeaponList.GetBeatNode(eWeapon));
            // obj.name = obj.name + StaticVariable.iNodeCount;
            // //obj.transform.GetComponent<csNodeControl>().Init();
            //
            // StaticVariable.NodeCounting();
        }
    }



    //--------------------------------------------------
    // IWeaponClass ????? ?? ??
    //--------------------------------------------------
    public void Damage()
    {

    }
    
    
    
    //--------------------------------------------------
    // WeaponObjectClass? ?? ??
    //--------------------------------------------------
    
    // ??? ?? ?? ??. Return (??? ??) , (? ??)
    public (int, int) GetNodeBeatPropertyCounts()
    {
        int full_cnt = 0;
        int empty_cnt = 0;

        foreach (bool b in m_beats)
        {
            if (b)
                ++full_cnt;
            else
                ++empty_cnt;
        }
        
        return (full_cnt, empty_cnt);
    }
}
