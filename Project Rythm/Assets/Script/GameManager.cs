using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 인스턴스 객체 생성
    private static GameManager instance = null;


    //프로젝트 실행 단계에서 실행
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //다른 객체에서 해당 싱글톤에 접근할 때 사용한는 매서드
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }

    }


    //----------------------------------------------------------------------------------------------------
    // 사용할 매서드 아래에서 구현 ↓↓↓
    //----------------------------------------------------------------------------------------------------


    public BeatSystem BeatSystemScript()
    {
        return this.gameObject.GetComponent<BeatSystem>();
    }


    // 일정 시간 후 동작하는 매서드
    public delegate void DelayAfterFunc();
    public IEnumerator DelayTime(float time, DelayAfterFunc func)
    {
        yield return new WaitForSeconds(time);

        if (func != null)
        {
            print("들옴");
            func();
        }
    }
}
