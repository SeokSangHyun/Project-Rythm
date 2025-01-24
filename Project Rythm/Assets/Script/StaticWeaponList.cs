using UnityEngine;

using System.Collections;
using System.Collections.Generic;


public enum NodeType
{
    Test,
    OnlyBeat,
    Normal,
}




public static class StaticWeaponList
{
    //
    public static Dictionary<EnumWeapon, GameObject> list_prefab = new Dictionary<EnumWeapon, GameObject>();


    // 
    public static void WeaponDataLoad()
    {
        //list_prefab 
        GameObject[] objs = Resources.LoadAll<GameObject>("Prefab/Weapon");
    }




    //----------------------------------------------------------------------------------------------------
    // �ʿ��� ���� ���⸦ �Ʒ� �Լ����� ���ؼ� ���� �� ����
    //----------------------------------------------------------------------------------------------------

    //무기 반환
    public static GameObject GetWeapon(EnumWeapon e_weapon)
    {
        return list_prefab[e_weapon];
    }

    // //��带 ��ȯ��
    // public static GameObject GetBeatNode(EnumWeapon e_weapon)
    // {
    //     if ( !list_prefab.ContainsKey(e_weapon) )
    //     {
    //         //print("���⿡ �ش��ϴ� ��� ��ü�� �����ϴ�.");
    //         return null;
    //     }
    //
    //     WeaponClass weapon = list_prefab[e_weapon].GetComponent<WeaponObjectClass>();
    //     GameObject obj = Resources.Load<GameObject>("Prefab/prefab_Dagger");;
    //     
    //     return obj;
    // }
    //
    //
    // //���⸦ ��ȯ��
    // public static GameObject GetWeapon(EnumWeapon e_weapon)
    // {
    //     if (!list_prefab.ContainsKey(e_weapon))
    //     {
    //         //print("���⿡ �ش��ϴ� ���� ��ü�� �����ϴ�.");
    //         return null;
    //     }
    //
    //     WeaponClass weapon = list_prefab[e_weapon].GetComponent<WeaponObjectClass>();
    //     GameObject obj = Resources.Load<GameObject>("Prefab/prefab_Dagger");;
    //     
    //     return obj;
    // }


}
