using UnityEngine;

//--------------------------------------------------
// 빈 노드의 액션 클래스
//--------------------------------------------------
public class OnlyBeatNodeClass : MonoBehaviour, INodeActionClass
{
    [SerializeField]
    private NodeType _nodeType;
    public NodeType nodeType
    {
        get => _nodeType;
        set => _nodeType = value;
    }

    public int RailIndex { get; private set; } = 0;
    public int BeatTimming { get; private set; } = 1;
    public int Maintain { get; private set; } = 0;
    public int CoolTime { get; private set; } = 0;

    // 노드 생성
    public void CreateBeatNode(int accCount)
    {


        //GameObject obj = Instantiate(WeaponList.GetBeatNode( gameObject.NodeType nodeType));
        //obj.name = obj.name + iNodeCount;


        //++iNodeCount;
    }


    // 버튼 클릭 시 매서드
    public void OnClickEvent()
    {
        // 해당 클래스는 버튼 입력 없음
    }


    // 조건 만족했을 때 행동 발동 매서드
    public void AttackEvent()
    {
        print("OnlyBeat Node");

        // 해당 클래스는 공격 없음
    }

}