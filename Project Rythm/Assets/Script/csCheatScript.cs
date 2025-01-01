//--------------------------------------------------
// 운영툴 기능
//--------------------------------------------------
using System;
using UnityEngine;
using UnityEngine.UI;

public class csCheatScript : MonoBehaviour
{
    public GameObject MainCheatButton;
    public GameObject CheatPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //메인 UI 처리
        MainCheatButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.Instance.SetIsPause(true);
            CheatPanel.SetActive(true);

            // 종료 시 처리
            //WeaponList.InitItem();
        });

        //Panel 처리
        Button close_btn = CheatPanel.transform.Find("CloseButton").GetComponent<Button>();
        close_btn.onClick.AddListener(() =>
        {
            GameManager.Instance.SetIsPause(false);
            CheatPanel.SetActive(false);

            //게임 시작 처리
            //GameManager.Instance.AddItem(NodeType.Normal);
        });

        Transform weapon_group = CheatPanel.transform.Find("Scroll View/Viewport/Content");

        for (int i = 0; i < weapon_group.childCount; i++)
        {
            Transform child = weapon_group.GetChild(i);
            Button btn = child.Find("Button").GetComponent<Button>();

            btn.onClick.AddListener(() => ButtonEvent_Equip(btn));
        }

    }

    // Update is called once per frame
    void Update() {}


    //----------------------------------------------------------------------------------------------------
    
    private void ButtonEvent_Equip(Button btn)
    {
        Debug.Log("Clicked button: " + btn.transform.parent.name);

        string SelectWeaponName = btn.transform.parent.name;
        EnumWeapon _e;
        if ( ! Enum.TryParse(SelectWeaponName, true, out _e) )
        {
            print("Enum 없음");
            return;
        }


        //여기 장착 처리
        WeaponManager.Instance.EquipItem(_e);
    }
}
