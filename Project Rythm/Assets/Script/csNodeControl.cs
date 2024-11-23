using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum NodeCheckType
{
    Miss,
    Normal,
    Good,
    Perfect
}



public class csNodeControl : MonoBehaviour
{
    //------------------------------Prefab 변수들


    //------------------------------사용 대상 객체
    private GameObject MainCanvas;




    //------------------------------시스템 변수들
    public NodeType m_nodeType;


    // 체크 타입에 대한 변수들
    private NodeCheckType eNodeCheckType = NodeCheckType.Miss;
    private float MissDist = 200.0f;
    private float NormalDist = 80.0f;
    private float GoodDist = 30.0f;
    private float PerfectDist = 15.0f;



    //------------------------------사용할 변수들
    private GameObject m_nodeParent;
    private RectTransform m_rectTransform;

    private float m_moveSpeed = 200.0f;


    private Vector2 ClearAreaLocation;

    private float m_distance = 1.0f;


    // 노드 상태 확인용 변수
    private bool IsInit = false;
    private bool IsAreaIn = false;
    private bool IsDead = false;


    // 객체 초기화
    void Start()
    {
        MainCanvas = GameObject.Find("MainCanvas");
        m_nodeParent = MainCanvas.transform.Find("CheckArea").gameObject;

        gameObject.transform.parent = m_nodeParent.transform;

        m_rectTransform = gameObject.GetComponent<RectTransform>();
        m_rectTransform.anchoredPosition = Vector2.zero + new Vector2(-200, 0);

        IsInit = true;
    }

    // Update is called once per frame
    void Update()
    {
        //초기화 안했다면 반환 처리
        if (!IsInit) { return; }

        //노드 움직임 갱신
        m_rectTransform.anchoredPosition += new Vector2(m_moveSpeed * Time.deltaTime, 0);

        // 노드의 상태 처리
        CheckAreaCondition();

        // 노드의 타입 처리
        eNodeCheckType = CheckNodeType();
    }


    public NodeCheckType NodeCheckTypeStatus
    {
        get { return eNodeCheckType; }
        private set { eNodeCheckType = value; }
    }


    //--------------------------------------------------
    // 버튼의 타입 체크
    //--------------------------------------------------
    NodeCheckType CheckNodeType()
    {
        if (IsDead) { return NodeCheckType.Miss; }

        float distance = Vector2.Distance(m_nodeParent.transform.position, m_rectTransform.position);

        if (0 <= distance && distance < PerfectDist)
        {
            return NodeCheckType.Perfect;
        }
        else if (PerfectDist <= distance && distance < GoodDist)
        {
            return NodeCheckType.Good;
        }
        else if (GoodDist <= distance && distance < NormalDist)
        {
            return NodeCheckType.Normal;
        }
        else
        {
            return NodeCheckType.Miss;
        }
    }


    //--------------------------------------------------
    // 버튼의 타입 체크
    //--------------------------------------------------
    void CheckAreaCondition()
    {

        //나갔을 때 처리
        if (!IsDead && m_rectTransform.anchoredPosition.x >= m_nodeParent.GetComponent<RectTransform>().sizeDelta.x / 2)
        {
            IsDead = true;

            if (m_nodeType != NodeType.Test && m_nodeType != NodeType.OnlyBeat)
            {
                print("OUT < " + gameObject.name);
                GameManager.Instance.RemoveInClearNode();
            }
            //StartCoroutine(GameManager.Instance.DelayTime(0.5f, () => Destroy(gameObject)));
            Destroy(gameObject, 1.0f);
        }

        //들어왔을 때 처리
        if (!IsAreaIn && -m_nodeParent.GetComponent<RectTransform>().sizeDelta.x / 2 <= m_rectTransform.anchoredPosition.x)
        {
            IsAreaIn = true;

            if (m_nodeType != NodeType.Test && m_nodeType != NodeType.OnlyBeat)
            {
                print("IN >> " + gameObject.name);
                GameManager.Instance.AddInClearNode(gameObject);
            }
        }
    }


    public void CreateTFX()
    {
        GameObject prefab;
        GameObject tfx;
        if (eNodeCheckType == NodeCheckType.Normal)
        {
            //Normal
            prefab = Resources.Load<GameObject>("Prefab/TFX_Normal");
        }
        else if (eNodeCheckType == NodeCheckType.Good)
        {
            //Good
            prefab = Resources.Load<GameObject>("Prefab/TFX_Good");
        }
        else if (eNodeCheckType == NodeCheckType.Perfect)
        {
            //Perfect
            prefab = Resources.Load<GameObject>("Prefab/TFX_Perfect");
        }
        else
        {
            prefab = Resources.Load<GameObject>("Prefab/TFX_Miss");
        }

        tfx = Instantiate(prefab);
        tfx.transform.parent = MainCanvas.transform;
        tfx.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        Destroy(tfx, 1.0f);
    }





    //--------------------------------------------------
    // 버튼 입력 체크
    //--------------------------------------------------
    void OnTriggerEnter2D(Collider2D collision)
    {
    }

    void OnTriggerExit2D(Collider2D collision)
    {

    }
}








