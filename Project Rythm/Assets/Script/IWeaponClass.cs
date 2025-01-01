using UnityEngine;


public enum EnumWeapon
{
    Test,
    Empty,
    Manaball,
    Dagger,
    RayserBeam,
    Sword,
}


//--------------------------------------------------
// 장비의 리듬에 대한 Interface Class
//--------------------------------------------------
public interface IWeaponClass
{
    //노드 용 변수
    EnumWeapon eWeapon { get; }

    void Damage();               //비트 체크
}
