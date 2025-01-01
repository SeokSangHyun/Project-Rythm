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
    //노드 용 변수
    protected EnumWeapon eWeapon { get; set; }
    
    public virtual void Init(EnumWeapon _e)
    {
        eWeapon = _e;
    }

    public virtual void Damage()
    {
        
    }
}
