using UnityEngine;
using UnityEngine.UI;

public class csCheckAreaButton : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }
    // Update is called once per frame
    void Update() { }



    //----------------------------------------------------------------------------------------------------
    // ����� �ż��� �Ʒ����� ���� ����
    //----------------------------------------------------------------------------------------------------

    // �浹 ������ ������ �� ( collision �浹�� ��ü )
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.name);
        //GameManager.Instance.AddInClearNode(collision.gameObject);
    }

    // �浹 ������ ������ �� ( collision �浹�� ��ü )
    private void OnTriggerExit2D(Collider2D collision)
    {
        //print(collision.gameObject.name);
        //GameManager.Instance.RemoveInClearNode(collision.gameObject);
    }

}
