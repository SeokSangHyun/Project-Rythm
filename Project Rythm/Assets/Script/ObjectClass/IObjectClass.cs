

using UnityEngine;


//--------------------------------------------------
// 모든 오브젝트의 기본 속성을 가진 Object Interface
//--------------------------------------------------
public interface IObjectClass
{
    string      Name { get; }
    float       HP {  get; }

    void Attack();          // 공격 매서드
    void Hit(float damage);             // 맞았을 때 매서드
    void Skill();          // 스킬 사용하는 매서드
}

