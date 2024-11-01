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



    // 객체 초기화
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
//    public float duration = 1.0f;  // 포물선 운동의 지속 시간
//    public float height = 100.0f;  // 포물선의 최대 높이
//    public float distance = 200.0f;  // x축 이동 거리

//    private Vector2 startPosition;
//    private bool isMoving = false;
//    private float elapsedTime = 0f;

//    void Start()
//    {
//        // 버튼의 시작 위치를 저장합니다.
//        startPosition = buttonRectTransform.anchoredPosition;

//        // 버튼에 클릭 이벤트를 추가합니다.
//        GetComponent<Button>().onClick.AddListener(StartParabolaMovement);
//    }

//    void Update()
//    {
//        if (isMoving)
//        {
//            elapsedTime += Time.deltaTime;

//            // t는 0에서 1까지 증가하며, 운동이 끝나면 멈춥니다.
//            float t = elapsedTime / duration;
//            if (t > 1.0f)
//            {
//                t = 1.0f;
//                isMoving = false;
//            }

//            // 포물선 운동 수식: x = distance * t, y = height * (1 - (2 * t - 1)^2)
//            float x = distance * t;
//            float y = height * (1 - Mathf.Pow(2 * t - 1, 2));

//            // 새 위치 계산 (원래 위치 + 계산된 x, y)
//            buttonRectTransform.anchoredPosition = startPosition + new Vector2(x, y);
//        }
//    }

//    void StartParabolaMovement()
//    {
//        if (!isMoving)
//        {
//            // 변수 초기화
//            elapsedTime = 0f;
//            isMoving = true;
//        }
//    }
//}






