using UnityEngine;
using UnityEngine.UI;

public class csCheckAreaSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }


    //----------------------------------------------------------------------------------------------------
    // ����� �ż��� �Ʒ����� ���� ����
    //----------------------------------------------------------------------------------------------------

    void OnButtonClick()
    {
        //GameManager.Instance.RemoveInClearNode();
        Destroy(gameObject);
    }




}
