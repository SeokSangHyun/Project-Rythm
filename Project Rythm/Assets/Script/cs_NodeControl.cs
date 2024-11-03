using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum NodeType
{
    Normal,
    MiddleSpot,
    FireCrack
}



public class cs_NodeControl : MonoBehaviour
{
    private GameObject          MainCanvas;
    private Canvas              m_canvas;
    private GameObject          m_nodeParent;

    private Vector2             ClearAreaLocation;

    private RectTransform       rectTransform;
    private float               m_distance = 1.0f;
    private float               speed               = 0.1f;


    private bool                IsInit = false;


    // ∞¥√º √ ±‚»≠
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
        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInit)
        {

            if (Vector2.Distance(m_nodeParent.transform.position, rectTransform.position) <= m_distance)
            {
                GameManager.Instance.RemoveInClearNode(gameObject);
                StartCoroutine( GameManager.Instance.DelayTime(0.5f, () => Destroy(gameObject)) );
            }
            else
            {
                rectTransform.anchoredPosition += new Vector2(speed + Time.deltaTime, 0);
            }
        }
    }



    void OnButtonClick()
    {
        //Destroy(gameObject);
    }

}








