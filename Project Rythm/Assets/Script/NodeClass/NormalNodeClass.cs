//--------------------------------------------------
// 무기 전체의 기능을 가진 Weapon Interface
//--------------------------------------------------
using UnityEngine;

public class NormalNodeClass : MonoBehaviour, INodeActionClass
{
    public void OnClickEvent()    // 버튼 클릭 시 매서드
    {
        AttackEvent();
        Destroy(gameObject);
    }


    public void AttackEvent()     // 조건 만족했을 때 행동 발동 매서드
    {
        csNodeControl controlScript = gameObject.GetComponent<csNodeControl>();
        GameObject obj = Instantiate(WeaponList.GetWeapon(controlScript.m_nodeType), new Vector3(0, 0, 0), Quaternion.identity);
    }

}