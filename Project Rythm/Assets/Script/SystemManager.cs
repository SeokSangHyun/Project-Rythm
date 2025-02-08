using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    private static SystemManager instance = null;

    // >> 게임 일시 정지 변수
    private bool IsPause = true;

    // >> 무슨 변수지?
    private Queue<GameObject> InClearNode = new Queue<GameObject>();

    // >> 지금 진행중인 몬스터의 난이도 ( 0 : 기본 난이도. 난이도는 오름차순)
    private int Difficulty = 0;
    

    //������Ʈ ���� �ܰ迡�� ����
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

    // GameMager Instance -> 무조건 이 겻으로 맵버 변수와 함수를 접근해야함 
    public static SystemManager Instance
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
    
    // IsPause에 대한 Getter/Setter
    public bool CheckIsPause() { return IsPause; }
    public void SetIsPause(bool ispause) { IsPause = ispause; }

    // Difficuly에 대한 Getter/Setter
    public int GetDifficulty() { return Difficulty; }
    public void SetDifficulty(int idifficulty) { Difficulty = idifficulty; }
    
    

    //----------------------------------------------------------------------------------------------------
    // ����� �ż��� �Ʒ����� ���� ����
    //----------------------------------------------------------------------------------------------------


    public BeatSystem BeatSystemScript()
    {
        return this.gameObject.GetComponent<BeatSystem>();
    }


    // ���� �ð� �� �����ϴ� �ż���
    public delegate void DelayAfterFunc();
    public IEnumerator DelayTime(float time, DelayAfterFunc func)
    {
        yield return new WaitForSeconds(time);

        if (func != null)
        {
            func();
        }
    }


    //----------------------------------------------------------------------------------------------------
    // Ŭ���� ������ �ִ� ���
    //----------------------------------------------------------------------------------------------------

    //Ŭ���� ������ ��� �߰�
    public void AddInClearNode(GameObject obj)
    {
        this.InClearNode.Enqueue(obj);
        //print("------------------------");
    }


    //Ŭ���� �������� ��� ����
    public GameObject RemoveInClearNode()
    {
        //������ ��尡 ���� �� ó��.
        if (this.InClearNode.Count <= 0)
        {
            print("������ ��尡 �����ϴ�.");
            return null;
        }

        return this.InClearNode.Dequeue();
    }


}
