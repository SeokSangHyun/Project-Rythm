using UnityEngine;
using UnityEngine.UI;

public class csCheckAreaSystem : MonoBehaviour
{

    private bool IsClick = false;


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

        GameObject obj = SystemManager.Instance.RemoveInClearNode();
        if (obj == null)
        {
            print("������ ��尡 ����");
            return;
        }
        print("Click < " + obj);

        INodeActionClass classScript = obj.GetComponent<INodeActionClass>();
        classScript.OnClickEvent();

        //
        csNodeControl controlScript = obj.GetComponent<csNodeControl>();
        controlScript.CreateTFX();

        Transform child = GameObject.Find("MonsterRoot").transform.GetChild(0);
        IObjectClass enemy = child.GetComponent<IObjectClass>();
        enemy.Hit(10.0f);
    }
}
