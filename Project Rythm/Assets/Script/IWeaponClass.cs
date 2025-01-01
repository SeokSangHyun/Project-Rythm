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
// ����� ���뿡 ���� Interface Class
//--------------------------------------------------
public interface IWeaponClass
{
    //��� �� ����
    EnumWeapon eWeapon { get; }

    void Damage();               //��Ʈ üũ
}
