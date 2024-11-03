using UnityEngine;

public class CheckActionInputScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    void OnButtonClick()
    {
        CheckBeatInput();
    }



    //--------------------------------------------------
    // 버튼 입력 체크
    //--------------------------------------------------
    NodeCheckType CheckBeatInput()
    {
        //float distance = Vector2.Distance(m_nodeParent.transform.position, rectTransform.position);

        //if (-2 <= distance && distance < PerfectDist)
        //{
        //    return NodeCheckType.Perfect;
        //}
        //else if (PerfectDist <= distance && distance < GoodDist)
        //{
        //    return NodeCheckType.Good;
        //}
        //else if (GoodDist <= distance && distance < NormalDist)
        //{
        //    return NodeCheckType.Normal;
        //}
        //else
        //{
        //    return NodeCheckType.Miss;
        //}
    }
}
