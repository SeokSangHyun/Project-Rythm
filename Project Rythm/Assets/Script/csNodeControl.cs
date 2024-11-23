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
    private NodeCheckType eNodeCheckType = NodeCheckType.Miss;
    private float MissDist = 200.0f;
    private float NormalDist = 80.0f;
    private float GoodDist = 30.0f;
    private float PerfectDist = 15.0f;



    //------------------------------����� ������
    private GameObject m_nodeParent;
    private RectTransform m_rectTransform;

    private float m_moveSpeed = 200.0f;


    private Vector2 ClearAreaLocation;

    private float m_distance = 1.0f;


    // ��� ���� Ȯ�ο� ����
    private bool IsInit = false;
    private bool IsAreaIn = false;
    private bool IsDead = false;


    // ��ü �ʱ�ȭ
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
        //�ʱ�ȭ ���ߴٸ� ��ȯ ó��
        if (!IsInit) { return; }

        //��� ������ ����
        m_rectTransform.anchoredPosition += new Vector2(m_moveSpeed * Time.deltaTime, 0);

        // ����� ���� ó��
        CheckAreaCondition();

        // ����� Ÿ�� ó��
        eNodeCheckType = CheckNodeType();
    }


    public NodeCheckType NodeCheckTypeStatus
    {
        get { return eNodeCheckType; }
        private set { eNodeCheckType = value; }
    }


    //--------------------------------------------------
    // ��ư�� Ÿ�� üũ
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
    // ��ư�� Ÿ�� üũ
    //--------------------------------------------------
    void CheckAreaCondition()
    {

        //������ �� ó��
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

        //������ �� ó��
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
    // ��ư �Է� üũ
    //--------------------------------------------------
    void OnTriggerEnter2D(Collider2D collision)
    {
    }

    void OnTriggerExit2D(Collider2D collision)
    {

    }
}








