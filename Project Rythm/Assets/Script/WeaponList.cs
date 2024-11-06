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
    //무기 모음
    static Dictionary<NodeType, (GameObject Node, GameObject Weapon)> list_prefab = new Dictionary<NodeType, (GameObject, GameObject)>();

    //노드 프리팹
    [Header("Beat Node")]
    public GameObject prefab_node_test;
    public GameObject prefab_node_onlybeat;
    public GameObject prefab_node_normal;


    //무기 프리팹
    [Header("Weapon Object")]
    public GameObject prefab_weapon_test;
    public GameObject prefab_weapon_manaball;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 여기에 무기가 추가될 때마다 추가해줘야함
    void Start()
    {
        list_prefab.Add(NodeType.OnlyBeat, (prefab_node_test, prefab_weapon_test));                     // 비트용 오브젝트
        list_prefab.Add(NodeType.OnlyBeat, (prefab_node_onlybeat, null));                               // 비트용 오브젝트
        list_prefab.Add(NodeType.OnlyBeat, (prefab_node_normal, prefab_weapon_manaball));               // 비트용 오브젝트

    }




    //----------------------------------------------------------------------------------------------------
    // 필요한 노드와 무기를 아래 함수들을 통해서 얻을 수 있음
    //----------------------------------------------------------------------------------------------------

    //노드를 반환함
    public static GameObject GetBeatNode(NodeType node_type)
    {
        if ( !list_prefab.ContainsKey(node_type) )
        {
            print("무기에 해당하는 노드 객체가 없습니다.");
            return null;
        }

        return list_prefab[node_type].Node;
    }


    //무기를 반환함
    public static GameObject GetWeapon(NodeType node_type)
    {
        if (!list_prefab.ContainsKey(node_type))
        {
            print("무기에 해당하는 무기 객체가 없습니다.");
            return null;
        }

        return list_prefab[node_type].Weapon;
    }

}
