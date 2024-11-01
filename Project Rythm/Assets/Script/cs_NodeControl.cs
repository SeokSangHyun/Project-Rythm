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
    private bool                isButtonON          = false;

    private float               speed               = 100;
    private RectTransform       rectTransform, startPosition;

    private float f;



    // ��ü �ʱ�ȭ
    public void Initialize()
    {
        Canvas canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        rectTransform = gameObject.GetComponent<RectTransform>();

        gameObject.transform.parent = canvas.transform;
        rectTransform.anchoredPosition = new Vector2(0, -Screen.height/2 + 100);


    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (isButtonON)
        {

        }
        else
        {
            rectTransform.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);
        }
    }



    void OnButtonClick()
    {
        isButtonON = true;

        startPosition = gameObject.GetComponent<RectTransform>();
        //Destroy(gameObject);
    }
}



//public class ParabolaMovement : MonoBehaviour
//{
//    public RectTransform buttonRectTransform;
//    public float duration = 1.0f;  // ������ ��� ���� �ð�
//    public float height = 100.0f;  // �������� �ִ� ����
//    public float distance = 200.0f;  // x�� �̵� �Ÿ�

//    private Vector2 startPosition;
//    private bool isMoving = false;
//    private float elapsedTime = 0f;

//    void Start()
//    {
//        // ��ư�� ���� ��ġ�� �����մϴ�.
//        startPosition = buttonRectTransform.anchoredPosition;

//        // ��ư�� Ŭ�� �̺�Ʈ�� �߰��մϴ�.
//        GetComponent<Button>().onClick.AddListener(StartParabolaMovement);
//    }

//    void Update()
//    {
//        if (isMoving)
//        {
//            elapsedTime += Time.deltaTime;

//            // t�� 0���� 1���� �����ϸ�, ��� ������ ����ϴ�.
//            float t = elapsedTime / duration;
//            if (t > 1.0f)
//            {
//                t = 1.0f;
//                isMoving = false;
//            }

//            // ������ � ����: x = distance * t, y = height * (1 - (2 * t - 1)^2)
//            float x = distance * t;
//            float y = height * (1 - Mathf.Pow(2 * t - 1, 2));

//            // �� ��ġ ��� (���� ��ġ + ���� x, y)
//            buttonRectTransform.anchoredPosition = startPosition + new Vector2(x, y);
//        }
//    }

//    void StartParabolaMovement()
//    {
//        if (!isMoving)
//        {
//            // ���� �ʱ�ȭ
//            elapsedTime = 0f;
//            isMoving = true;
//        }
//    }
//}






