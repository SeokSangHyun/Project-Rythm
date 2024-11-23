using UnityEngine;
using UnityEngine.UI;

public class MonsterClass : MonoBehaviour, IObjectClass
{
    public string   Name { get; private set; }
    public float HP { get; private set; } = 100.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { }

    // Update is called once per frame
    void Update()
    { }


    //----------------------------------------------------------------------------------------------------
    public void Attack()
    {

    }


    public void Hit(float damage)
    {

        GameObject canvas = GameObject.Find("Canvas");

        Slider slider = canvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Slider>();

        HP -= damage;
        slider.value = HP/100.0f;

    }


    public void Skill()
    {

    }
}

