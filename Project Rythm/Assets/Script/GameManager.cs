using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �ν��Ͻ� ��ü ����
    private static GameManager instance = null;


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
            print("���");
            func();
        }
    }
}
