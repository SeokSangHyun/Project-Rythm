

using UnityEngine;


//--------------------------------------------------
// ��� ������Ʈ�� �⺻ �Ӽ��� ���� Object Interface
//--------------------------------------------------
public interface IObjectClass
{
    string      Name { get; }
    float       HP {  get; }

    void Attack();          // ���� �ż���
    void Hit(float damage);             // �¾��� �� �ż���
    void Skill();          // ��ų ����ϴ� �ż���
}

