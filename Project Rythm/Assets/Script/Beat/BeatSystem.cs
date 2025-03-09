using UnityEngine;
using UnityEngine.Audio;


//게임 플레이 씬에서 비트가 흘러가는 것에 대한 기능을 담당하는 클래스
public class BeatSystem : MonoBehaviour
{
    // Audio 변수
    private AudioSource audioSource;
    public AudioClip audioClip;

    // 비트 데이터 변수
    private     bool        IsBeat = false;

    private     float       fInterval = 0.25f;
    private     float       fWaitTime = 0.0f;

    private     BeatDataManagerClass scriptBeatDataManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume -= 0.95f;
        
        scriptBeatDataManager = GetComponent<BeatDataManagerClass>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SystemManager.Instance.CheckIsPause() && !SystemManager.Instance.GetIsGamePlay()) { return; }

        if ( BeatUpdate(Time.deltaTime) )
        {
            IsBeat = false;
            
            //InvokeBeat 요거 실행해야함
            scriptBeatDataManager.InvokeBeat();
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
            StaticVariable.iBeatAccCount += 1;


            //CreateBeatNode(NodeType.OnlyBeat);

            audioSource.Play();

            return true;
        }

        return false;
    }
    
}


