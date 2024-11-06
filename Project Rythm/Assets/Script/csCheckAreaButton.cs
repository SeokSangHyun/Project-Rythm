using UnityEngine;
using UnityEngine.UI;

public class csCheckAreaSystem : MonoBehaviour
{

    private bool            IsClick = false;


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
        IsClick = !IsClick;

        //

        GameObject obj = GameManager.Instance.RemoveInClearNode();
        if (obj != null)
        {
            Destroy(obj);

            //���⼭ ���� �ൿ �׼�
        }
    }




}
