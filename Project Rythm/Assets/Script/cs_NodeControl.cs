using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum NodeType
{
    OnlyBeat,
    Normal,
    MiddleSpot,
    FireCrack
}

public enum NodeCheckType
{
    Miss,
    Normal,
    Good,
    Perfect
}



public class cs_NodeControl : MonoBehaviour
{
    // 체크 타입에 대한 변수들
    public NodeType             NodeType;
    private float               MissDist = 50.0f;
    private float               NormalDist = 30.0f;
    private float               GoodDist = 10.0f;
    private float               PerfectDist = 5.0f;



    //사용 객체
    private GameObject          MainCanvas;
    private Canvas              m_canvas;
    private GameObject          m_nodeParent;

    private Vector2             ClearAreaLocation;

    private RectTransform       rectTransform;
    private float               speed               = 0.8f;


    //

    private float               m_distance = 1.0f;


    // 노드 상태 확인용 변수
    private bool                IsInit = false;
    private bool                IsDead = false;


    // 객체 초기화
    public void Initialize()
    {
        MainCanvas = GameObject.Find("MainCanvas");
        m_canvas = MainCanvas.GetComponent<Canvas>();
        m_nodeParent = m_canvas.transform.Find("DefaultBeatArea").gameObject;

        gameObject.transform.parent = m_nodeParent.transform;
        ClearAreaLocation = m_nodeParent.GetComponent<RectTransform>().anchoredPosition;

        rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero + new Vector2(-150, 0);

        IsInit = true;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInit)
        {

            if (!IsDead &&
                Vector2.Distance(m_nodeParent.transform.position, rectTransform.position) <= m_distance)
            {
<<<<<<< Updated upstream
                GameManager.Instance.RemoveInClearNode(gameObject);
                StartCoroutine( GameManager.Instance.DelayTime(0.5f, () => Destroy(gameObject)) );
            }
            else
            {
                rectTransform.anchoredPosition += new Vector2(speed + Time.deltaTime, 0);
=======
                IsDead = true;
                StartCoroutine( GameManager.Instance.DelayTime(0.3f, () => Destroy(gameObject)) );
>>>>>>> Stashed changes
            }

            rectTransform.anchoredPosition += new Vector2(speed + Time.deltaTime, 0);
        }
    }
<<<<<<< Updated upstream



    void OnButtonClick()
    {
        //Destroy(gameObject);
    }

=======
>>>>>>> Stashed changes
}








