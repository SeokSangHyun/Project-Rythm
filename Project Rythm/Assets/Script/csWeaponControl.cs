using UnityEngine;

public class csWeaponControl : MonoBehaviour
{
    Transform m_trans;
    float m_moveSpeed = 50.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        m_trans = gameObject.transform;

        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //노드 움직임 갱신
        m_trans.position += new Vector3(0, 0, m_moveSpeed * Time.deltaTime);
    }
}
