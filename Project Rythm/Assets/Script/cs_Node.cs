using UnityEngine;
using UnityEngine.UI;

public class cs_Node
{
    // ��ư ����
    //      1. ��ư�� �����ؾ��ϴ� ������
    //      2. ���� �� ��� �ð�
    //      3. ��带 ������ ��ġ (�׵θ� �ε���) --���� ����. ���� ���� ��
    //      4. ��� ������ ��Ʈ Ȥ�� ����

    private GameObject  prefBut;
    private float       iBitTime;
    private int         iBorder;
    private int         iSoundIndex;


    //---------- ---------- ---------- ---------- ----------

    public void CreateNode(int node_type, int bittime, int border)
    {
        switch (node_type)
        {
            case 1:
                break;
            case 2:
                break;
            default:
                prefBut = Resources.Load<GameObject>("Prefab/BitNodes/SideNode");
                iSoundIndex = 1;
                break;
        }


        iBitTime = bittime;
        iBorder = border;
    }


}
