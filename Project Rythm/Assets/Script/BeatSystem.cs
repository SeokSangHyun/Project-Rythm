using UnityEngine;
using UnityEngine.Audio;

public class BeatSystem : MonoBehaviour
{
    //사운드 추가
    private AudioSource audioSource;
    public AudioClip audioClip;


    // 비트 변수
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

            Invoke_BeatNode();     //일괄 실행

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
    // 노드 비트 계산
    //----------------------------------------------------------------------------------------------------

    // 내용 : 비트를 판단해서 반환
    //        True 반환
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


    // 내용 : 비트 노드 생성
    private void CreateBeatNode(NodeType nodeType)
    {
        GameObject obj = Instantiate( WeaponList.GetBeatNode(nodeType) );
        obj.name = obj.name + iNodeCount;


        ++iNodeCount;
    }

    // 내용 : 비트 노드 일괄 실행
    private void Invoke_BeatNode()
    {
        GameObject obj = Instantiate(WeaponList.GetBeatNode(NodeType.Test));
        obj.name = obj.name + iNodeCount;


        ++iNodeCount;
    }
    
}


