using UnityEngine;

//--------------------------------------------------
// �� ����� �׼� Ŭ����
//--------------------------------------------------
public class OnlyBeatNodeClass : MonoBehaviour, INodeActionClass
{

    public void OnClickEvent()    // ��ư Ŭ�� �� �ż���
    {
        // �ش� Ŭ������ ��ư �Է� ����
    }


    public void AttackEvent()     // ���� �������� �� �ൿ �ߵ� �ż���
    {
        print("OnlyBeat Node");

        // �ش� Ŭ������ ���� ����
    }

}