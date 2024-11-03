using UnityEngine;
using UnityEngine.UI;

public class cs_Node
{
    // 버튼 정보
    //      1. 버튼이 참조해야하는 프리팹
    //      2. 생성 후 대기 시간
    //      3. 노드를 생성할 위치 (테두리 인덱스) --원은 없다. 면이 많을 뿐
    //      4. 노드 생성할 비트 혹은 시점

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
