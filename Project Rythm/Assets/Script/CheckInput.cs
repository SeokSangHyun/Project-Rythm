using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckInput : MonoBehaviour
{

    //----------------------------------------------------------------------------------------------------
    // 기본 인터페이스
    //----------------------------------------------------------------------------------------------------

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //----------------------------------------------------------------------------------------------------
    // 사용할 매서드 아래에서 구현 ↓↓↓
    //----------------------------------------------------------------------------------------------------

    // 충돌 영역에 들어왔을 때 ( collision 충돌한 객체 )
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);

        GameManager.Instance.AddInClearNode(collision.gameObject);
    }

    // 충돌 영역에 나갔을 때 ( collision 충돌한 객체 )
    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision.gameObject.name);

        GameManager.Instance.RemoveInClearNode(collision.gameObject);
    }

}
