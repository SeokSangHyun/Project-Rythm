using UnityEngine;
using UnityEngine.Audio;

public class BeatSystem : MonoBehaviour
{
    //���� �߰�
    private AudioSource audioSource;
    public AudioClip audioClip;


    // ��Ʈ ����
    private     bool        IsBeat = false;
    private     int         iBeatAccCount, iNodeCount = 0;

    private     float       fInterval = 0.25f;
    private     float       fWaitTime = 0.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume -= 0.95f;

        GameManager.Instance.InitItem();
        GameManager.Instance.AddItem(NodeType.Normal);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CheckIsPause()) { return; }

        if ( BeatUpdate(Time.deltaTime) )
        {
            IsBeat = false;

            Invoke_BeatNode();     //�ϰ� ����

            //switch (iBeatAccCount%8)
            //{
            //    case 0:
            //        break;

            //    case 4:
            //        CreateBeatNode(NodeType.Normal);
            //        break;

            //    case 6:
            //        CreateBeatNode(NodeType.Normal);
            //        break;

            //    default:
            //        break;
            //}

            //print(iBeatAccCount + "Beat!");
        }
    }


    //----------------------------------------------------------------------------------------------------
    // ��� ��Ʈ ���
    //----------------------------------------------------------------------------------------------------

    // ���� : ��Ʈ�� �Ǵ��ؼ� ��ȯ
    //        True ��ȯ
    private bool BeatUpdate(float frame)
    {
        fWaitTime += frame;

        if (fWaitTime >= fInterval)
        {
            IsBeat = true;
            fWaitTime = 0.0f;
            iBeatAccCount += 1;


            //CreateBeatNode(NodeType.OnlyBeat);

            audioSource.Play();

            return true;
        }

        return false;
    }


    // ���� : ��Ʈ ��� ����
    private void CreateBeatNode(NodeType nodeType)
    {
        GameObject obj = Instantiate( WeaponList.GetBeatNode(nodeType) );
        obj.name = obj.name + iNodeCount;


        ++iNodeCount;
    }

    // ���� : ��Ʈ ��� �ϰ� ����
    private void Invoke_BeatNode()
    {
        GameObject obj = Instantiate(WeaponList.GetBeatNode(NodeType.Test));
        obj.name = obj.name + iNodeCount;


        ++iNodeCount;
    }
    
}


