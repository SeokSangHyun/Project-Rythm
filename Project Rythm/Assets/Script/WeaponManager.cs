using System.Collections.Generic;
using UnityEngine;



public class WeaponManager : MonoBehaviour
{
    //싱글톤화
    public static WeaponManager Instance { get; private set; }

    //해당 클래스 데이터
    private Dictionary<EnumWeapon, (GameObject Node, GameObject Weapon)> list_myWeapon = new Dictionary<eWeapon, (GameObject, GameObject)>();

    //----------------------------------------------------------------------------------------------------
    void Awake()
    {
        // 싱글톤 초기화
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // 기존 인스턴스가 있으면 새로 생성된 것을 파괴
            return;
        }
        Instance = this;

        // 싱글톤이 파괴되지 않도록 유지
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update(){}



    //----------------------------------------------------------------------------------------------------
    // 장착 무기 반환
    //----------------------------------------------------------------------------------------------------

    //장착한 무기 초기화
    public void InitItem()
    {
        list_myWeapon.Clear();

        EnumWeapon e_weapon = EnumWeapon.Empty;
        GameObject node = StaticWeaponList.GetBeatNode(e_weapon);
        GameObject weapon = StaticWeaponList.GetWeapon(e_weapon);

        list_myWeapon.Add(e_weapon, (node, weapon));
    }

    //장착한 무기 실행
    public void InvokeEquipItem_Node()
    {
        foreach ( KeyValuePair<EnumWeapon, (GameObject Node, GameObject Weapon)> pair in list_myWeapon)
        {
            pair.Value.Node.GetComponent<INodeActionClass>().Invoke();
        }
    }

    //----------------------------------------------------------------------------------------------------
    // 장착 / 해제
    //----------------------------------------------------------------------------------------------------

    //무기 장착하기
    public void EquipItem(EnumWeapon e_weapon)
    {
        GameObject node = StaticWeaponList.GetBeatNode(e_weapon);
        GameObject weapon = StaticWeaponList.GetWeapon(e_weapon);

        list_myWeapon.Add(e_weapon, (node, weapon));
    }

    //무기 장착 해제하기
    public void unEquipItem(EnumWeapon e_weapon)
    {
        if ( !list_myWeapon.ContainsKey(e_weapon) )
        {
            print("해당 무기를 장착하지 않았습니다.");
            return;
        }

        list_myWeapon.Remove(e_weapon);
    }

}
