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
    //------------------------------Prefab ������


    //------------------------------��� ��� ��ü
    private GameObject MainCanvas;




    //------------------------------�ý��� ������
    public NodeType m_nodeType;


    // üũ Ÿ�Կ� ���� ������
    private NodeCheckType       eNodeCheckType = NodeCheckType.Miss;
    private float               MissDist = 50.0f;
    private float               NormalDist = 30.0f;
    private float               GoodDist = 10.0f;
    private float               PerfectDist = 5.0f;



    //------------------------------����� ������
    private GameObject          m_nodeParent;
    private RectTransform       m_rectTransform;

    private float               m_moveSpeed = 0.8f;


    private Vector2             ClearAreaLocation;

    private float               m_distance = 1.0f;


    // ��� ���� Ȯ�ο� ����
    private bool                IsInit = false;
    private bool                IsAreaIn = false;
    private bool                IsDead = false;


    // ��ü �ʱ�ȭ
    public void Initialize()
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
        //�ʱ�ȭ ���ߴٸ� ��ȯ ó��
        if (!IsInit) { return; }

        // ���� ����� ���� ó��
        eNodeCheckType = CheckNodeType();

        //��� ������ ����
        m_rectTransform.anchoredPosition += new Vector2(m_moveSpeed + Time.deltaTime, 0);
    }



    //--------------------------------------------------
    // ��ư�� Ÿ�� üũ
    //--------------------------------------------------
    NodeCheckType CheckNodeType()
    {
        if (IsDead) { return NodeCheckType.Miss; }

        //������ �� ó��
        if (m_rectTransform.anchoredPosition.x >= m_nodeParent.GetComponent<RectTransform>().sizeDelta.x/2)
        {
            IsDead = true;
            IsAreaIn = false;

            if (m_nodeType != NodeType.OnlyBeat)
            {
                GameManager.Instance.RemoveInClearNode();
            }
            StartCoroutine(GameManager.Instance.DelayTime(0.5f, () => Destroy(gameObject)));
        }

        //������ �� ó��
        if (!IsAreaIn && - m_nodeParent.GetComponent<RectTransform>().sizeDelta.x / 2 <= m_rectTransform.anchoredPosition.x)
        {
            IsAreaIn = true;

            if (m_nodeType != NodeType.OnlyBeat)
            {
                GameManager.Instance.AddInClearNode(gameObject);
            }
        }


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
    // ��ư �Է� üũ
    //--------------------------------------------------
    void OnTriggerEnter2D(Collider2D collision)
    {
    }

    void OnTriggerExit2D(Collider2D collision)
    {

    }
}








