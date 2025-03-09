using UnityEngine;

using System.Collections;
using System.Collections.Generic;


public enum NodeType
{
    Test,
    OnlyBeat,
    Normal,
}




public class WeaponListSingleTone : MonoBehaviour
{
    private static WeaponListSingleTone instance = null;
    //
    public Dictionary<EnumWeapon, GameObject> list_prefab = new Dictionary<EnumWeapon, GameObject>();

    // GameMager Instance -> 무조건 이 겻으로 맵버 변수와 함수를 접근해야함 
    public static WeaponListSingleTone Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }

    }
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 변경 시 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        instance.WeaponDataLoad();
    }

    
    // 
    public void WeaponDataLoad()
    {
        //list_prefab 
        GameObject[] objs = Resources.LoadAll<GameObject>("Prefab/Weapon");

        for (int i = 0; i < objs.Length; i++)
        {
            WeaponObjectClass script = objs[i].GetComponent<WeaponObjectClass>();
            script.Init();
            EnumWeapon _e = script.GeteWeapon();
            list_prefab[_e] = objs[i];
        }
    }




    //----------------------------------------------------------------------------------------------------
    // �ʿ��� ���� ���⸦ �Ʒ� �Լ����� ���ؼ� ���� �� ����
    //----------------------------------------------------------------------------------------------------

    //무기 반환
    public GameObject GetWeapon(EnumWeapon e_weapon)
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
