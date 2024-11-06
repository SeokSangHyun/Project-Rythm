using UnityEngine;

using System.Collections;
using System.Collections.Generic;


public enum NodeType
{
    Test,
    OnlyBeat,
    Normal,
}



public class WeaponList : MonoBehaviour
{
    //���� ����
    static Dictionary<NodeType, (GameObject Node, GameObject Weapon)> list_prefab = new Dictionary<NodeType, (GameObject, GameObject)>();

    //��� ������
    [Header("Beat Node")]
    public GameObject prefab_node_test;
    public GameObject prefab_node_onlybeat;
    public GameObject prefab_node_normal;


    //���� ������
    [Header("Weapon Object")]
    public GameObject prefab_weapon_test;
    public GameObject prefab_weapon_manaball;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // ���⿡ ���Ⱑ �߰��� ������ �߰��������
    void Start()
    {
        list_prefab.Add(NodeType.OnlyBeat, (prefab_node_test, prefab_weapon_test));                     // ��Ʈ�� ������Ʈ
        list_prefab.Add(NodeType.OnlyBeat, (prefab_node_onlybeat, null));                               // ��Ʈ�� ������Ʈ
        list_prefab.Add(NodeType.OnlyBeat, (prefab_node_normal, prefab_weapon_manaball));               // ��Ʈ�� ������Ʈ

    }




    //----------------------------------------------------------------------------------------------------
    // �ʿ��� ���� ���⸦ �Ʒ� �Լ����� ���ؼ� ���� �� ����
    //----------------------------------------------------------------------------------------------------

    //��带 ��ȯ��
    public static GameObject GetBeatNode(NodeType node_type)
    {
        if ( !list_prefab.ContainsKey(node_type) )
        {
            print("���⿡ �ش��ϴ� ��� ��ü�� �����ϴ�.");
            return null;
        }

        return list_prefab[node_type].Node;
    }


    //���⸦ ��ȯ��
    public static GameObject GetWeapon(NodeType node_type)
    {
        if (!list_prefab.ContainsKey(node_type))
        {
            print("���⿡ �ش��ϴ� ���� ��ü�� �����ϴ�.");
            return null;
        }

        return list_prefab[node_type].Weapon;
    }

}
