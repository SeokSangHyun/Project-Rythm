using System.Collections.Generic;
using UnityEngine;



public class WeaponManager : MonoBehaviour
{
    //�̱���ȭ
    public static WeaponManager Instance { get; private set; }

    //�ش� Ŭ���� ������
    private Dictionary<EnumWeapon, (GameObject Node, GameObject Weapon)> list_myWeapon = new Dictionary<eWeapon, (GameObject, GameObject)>();

    //----------------------------------------------------------------------------------------------------
    void Awake()
    {
        // �̱��� �ʱ�ȭ
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // ���� �ν��Ͻ��� ������ ���� ������ ���� �ı�
            return;
        }
        Instance = this;

        // �̱����� �ı����� �ʵ��� ����
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update(){}



    //----------------------------------------------------------------------------------------------------
    // ���� ���� ��ȯ
    //----------------------------------------------------------------------------------------------------

    //������ ���� �ʱ�ȭ
    public void InitItem()
    {
        list_myWeapon.Clear();

        EnumWeapon e_weapon = EnumWeapon.Empty;
        GameObject node = StaticWeaponList.GetBeatNode(e_weapon);
        GameObject weapon = StaticWeaponList.GetWeapon(e_weapon);

        list_myWeapon.Add(e_weapon, (node, weapon));
    }

    //������ ���� ����
    public void InvokeEquipItem_Node()
    {
        foreach ( KeyValuePair<EnumWeapon, (GameObject Node, GameObject Weapon)> pair in list_myWeapon)
        {
            pair.Value.Node.GetComponent<INodeActionClass>().Invoke();
        }
    }

    //----------------------------------------------------------------------------------------------------
    // ���� / ����
    //----------------------------------------------------------------------------------------------------

    //���� �����ϱ�
    public void EquipItem(EnumWeapon e_weapon)
    {
        GameObject node = StaticWeaponList.GetBeatNode(e_weapon);
        GameObject weapon = StaticWeaponList.GetWeapon(e_weapon);

        list_myWeapon.Add(e_weapon, (node, weapon));
    }

    //���� ���� �����ϱ�
    public void unEquipItem(EnumWeapon e_weapon)
    {
        if ( !list_myWeapon.ContainsKey(e_weapon) )
        {
            print("�ش� ���⸦ �������� �ʾҽ��ϴ�.");
            return;
        }

        list_myWeapon.Remove(e_weapon);
    }

}
