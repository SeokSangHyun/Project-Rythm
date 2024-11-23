using UnityEngine;

public class PlayerClass : MonoBehaviour, IObjectClass
{
    public string      Name { get; private set; }
    public float       HP { get; private set; } = 100.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   }

    // Update is called once per frame
    void Update()
    {   }


    //----------------------------------------------------------------------------------------------------
    public void Attack()
    {

    }


    public void Hit(float damage)
    {


    }


    public void Skill()
    {

    }

}
