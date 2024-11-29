//--------------------------------------------------
// ���� ��ü�� ����� ���� Weapon Interface
//--------------------------------------------------
using UnityEngine;

public class NormalNodeClass : MonoBehaviour, INodeActionClass
{
    [SerializeField]
    private NodeType _nodeType;
    public NodeType nodeType
    {
        get => _nodeType;
        set => _nodeType = value;
    }

    public int RailIndex { get; private set; } = 1;
    public int BeatTimming { get; private set; } = 1;
    public int Maintain { get; private set; } = 0;
    public int CoolTime { get; private set; } = 2;

    public void OnClickEvent()    // ��ư Ŭ�� �� �ż���
    {
        AttackEvent();
        Destroy(gameObject);
    }


    public void AttackEvent()     // ���� �������� �� �ൿ �ߵ� �ż���
    {
        csNodeControl controlScript = gameObject.GetComponent<csNodeControl>();
        GameObject obj = Instantiate(WeaponList.GetWeapon(controlScript.m_nodeType), new Vector3(0, 0, 0), Quaternion.identity);
    }

}