//--------------------------------------------------
// ���� ��ü�� ����� ���� Weapon Interface
//--------------------------------------------------
using UnityEngine;

public class NormalNodeClass : MonoBehaviour, INodeActionClass
{
    public void OnClickEvent()    // ��ư Ŭ�� �� �ż���
    {
        print("Normal Node");

        Destroy(gameObject);
    }


    public void AttackEvent()     // ���� �������� �� �ൿ �ߵ� �ż���
    {
    }

}