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
    // 사용할 매서드 아래에서 구현 ↓↓↓
    //----------------------------------------------------------------------------------------------------

    void OnButtonClick()
    {
        IsClick = !IsClick;

        //

        GameObject          obj             = GameManager.Instance.RemoveInClearNode();
        print(obj.name);
        INodeActionClass    classScript     = obj.GetComponent<INodeActionClass>();

        if (classScript == null )
        {
            print("삭제할 노드가 없음");
            return;
        }
        classScript.OnClickEvent();
    }




}
