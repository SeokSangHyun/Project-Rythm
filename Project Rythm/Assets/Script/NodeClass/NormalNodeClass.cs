//--------------------------------------------------
// ���� ��ü�� ����� ���� Weapon Interface
//--------------------------------------------------
using UnityEngine;

public class NormalNodeClass : MonoBehaviour, INodeActionClass
{
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