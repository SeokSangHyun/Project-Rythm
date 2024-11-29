using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static TreeEditor.TreeEditorHelper;

public class GameManager : MonoBehaviour
{
    // 인스턴스 객체 생성
    private static GameManager instance = null;

    // 게임 관리 변수
    private bool IsPause = true;

    //인게임에 필요한 데이터
    private Queue<GameObject> InClearNode = new Queue<GameObject>();

    //장착한 무기
    private Dictionary<NodeType, (GameObject Node, GameObject Weapon)> list_myWeapon = new Dictionary<NodeType, (GameObject, GameObject)>();


    //프로젝트 실행 단계에서 실행
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //다른 객체에서 해당 싱글톤에 접근할 때 사용한는 매서드
    public static GameManager Instance
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

    public bool CheckIsPause()
    {
        return IsPause;
    }

    public void SetIsPause(bool ispause)
    {
        IsPause = ispause;
    }


    //----------------------------------------------------------------------------------------------------
    // 사용할 매서드 아래에서 구현 ↓↓↓
    //----------------------------------------------------------------------------------------------------


    public BeatSystem BeatSystemScript()
    {
        return this.gameObject.GetComponent<BeatSystem>();
    }


    // 일정 시간 후 동작하는 매서드
    public delegate void DelayAfterFunc();
    public IEnumerator DelayTime(float time, DelayAfterFunc func)
    {
        yield return new WaitForSeconds(time);

        if (func != null)
        {
            func();
        }
    }


    //----------------------------------------------------------------------------------------------------
    // 클리어 영역에 있는 노드
    //----------------------------------------------------------------------------------------------------

    //클리어 영역에 노드 추가
    public void AddInClearNode(GameObject obj)
    {
        this.InClearNode.Enqueue(obj);
        //print("------------------------");
    }


    //클리어 영역에서 노드 제거
    public GameObject RemoveInClearNode()
    {
        //제거할 노드가 없을 때 처리.
        if (this.InClearNode.Count <= 0)
        {
            print("제거할 노드가 없습니다.");
            return null;
        }

        return this.InClearNode.Dequeue();
    }


    //----------------------------------------------------------------------------------------------------
    // 장착 무기 반환
    //----------------------------------------------------------------------------------------------------

    //무기 장착하기
    public void InitItem()
    {
        list_myWeapon.Clear();

        NodeType nodeType = NodeType.OnlyBeat;
        list_myWeapon.Add(nodeType, (WeaponList.GetBeatNode(nodeType), WeaponList.GetBeatNode(nodeType)));
    }

    //무기 장착하기
    public void AddItem(NodeType node_type)
    {
        list_myWeapon.Add(node_type, (WeaponList.GetBeatNode(node_type), WeaponList.GetBeatNode(node_type)));
    }
}
