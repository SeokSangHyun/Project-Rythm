using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckInput : MonoBehaviour
{

    //----------------------------------------------------------------------------------------------------
    // �⺻ �������̽�
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
    // ����� �ż��� �Ʒ����� ���� ����
    //----------------------------------------------------------------------------------------------------

    // �浹 ������ ������ �� ( collision �浹�� ��ü )
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);

        GameManager.Instance.AddInClearNode(collision.gameObject);
    }

    // �浹 ������ ������ �� ( collision �浹�� ��ü )
    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision.gameObject.name);

        GameManager.Instance.RemoveInClearNode(collision.gameObject);
    }

}
