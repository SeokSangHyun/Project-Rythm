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
    //?? ? ??
    protected EnumWeapon eWeapon { get; set; }
    
    protected GameObject objNode { get; set; }
    protected GameObject objWeapon { get; set; }
    
    public virtual void Init(EnumWeapon _e)
    {
        eWeapon = _e;
    }

    public virtual void Damage()
    {
        
    }
}
