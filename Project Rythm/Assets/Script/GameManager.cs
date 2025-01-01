using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �ν��Ͻ� ��ü ����
    private static GameManager instance = null;

    // ���� ���� ����
    private bool IsPause = true;

    //�ΰ��ӿ� �ʿ��� ������
    private Queue<GameObject> InClearNode = new Queue<GameObject>();


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

    //�ٸ� ��ü���� �ش� �̱��濡 ������ �� ����Ѵ� �ż���
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

    public bool CheckIsPause()
    {
        return IsPause;
    }

    public void SetIsPause(bool ispause)
    {
        IsPause = ispause;
    }


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
