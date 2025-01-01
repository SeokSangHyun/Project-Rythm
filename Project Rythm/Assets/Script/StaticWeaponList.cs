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
    public static Dictionary<EnumWeapon, (GameObject Node, GameObject Weapon)> list_prefab = new Dictionary<EnumWeapon, (GameObject, GameObject)>();


    // 
    public static void WeaponDataLoad()
    {
        //��� ������
        GameObject prefab_node_test                = Resources.Load<GameObject>("Prefab/BitNodes/prefab_BeatNode_Test");
        GameObject prefab_node_onlybeat            = Resources.Load<GameObject>("Prefab/BitNodes/prefab_BeatNode_Arrow");
        GameObject prefab_node_normal = Resources.Load<GameObject>("Prefab/BitNodes/prefab_Normal_White_01");

        //���� ������
        GameObject prefab_weapon_test              = Resources.Load<GameObject>("Prefab/BitNodes/prefab_Weapon_Test");
        GameObject prefab_weapon_manaball = Resources.Load<GameObject>("Prefab/BitNodes/prefab_Weapon_ManaBall");


        //----------------------------------------------------------------------------------------------------
        // ���� ���
        list_prefab.Add(EnumWeapon.Test, (prefab_node_test, prefab_weapon_test));
        list_prefab.Add(EnumWeapon.Empty, (prefab_node_onlybeat, null));
        list_prefab.Add(EnumWeapon.Manaball, (prefab_node_normal, prefab_weapon_manaball));
        list_prefab.Add(EnumWeapon.Dagger, (prefab_node_normal, prefab_weapon_manaball));
        list_prefab.Add(EnumWeapon.RayserBeam, (prefab_node_normal, prefab_weapon_manaball));
        list_prefab.Add(EnumWeapon.Sword, (prefab_node_normal, prefab_weapon_manaball));
    }




    //----------------------------------------------------------------------------------------------------
    // �ʿ��� ���� ���⸦ �Ʒ� �Լ����� ���ؼ� ���� �� ����
    //----------------------------------------------------------------------------------------------------

    //��带 ��ȯ��
    public static GameObject GetBeatNode(EnumWeapon e_weapon)
    {
        if ( !list_prefab.ContainsKey(e_weapon) )
        {
            //print("���⿡ �ش��ϴ� ��� ��ü�� �����ϴ�.");
            return null;
        }

        return list_prefab[e_weapon].Node;
    }


    //���⸦ ��ȯ��
    public static GameObject GetWeapon(EnumWeapon e_weapon)
    {
        if (!list_prefab.ContainsKey(e_weapon))
        {
            //print("���⿡ �ش��ϴ� ���� ��ü�� �����ϴ�.");
            return null;
        }

        return list_prefab[e_weapon].Weapon;
    }


}
