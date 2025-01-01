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
// ?? ??? Weapon Class 
//--------------------------------------------------
public class WeaponClass : MonoBehaviour
{
    //��� �� ����
    protected EnumWeapon eWeapon { get; set; }
    
    public virtual void Init(EnumWeapon _e)
    {
        eWeapon = _e;
    }

    public virtual void Damage()
    {
        
    }
}
