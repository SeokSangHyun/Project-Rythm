using UnityEngine;
using UnityEngine.Audio;

public class BeatSystem : MonoBehaviour
{
    //사운드 추가
    private AudioSource audioSource;
    public AudioClip audioClip;


    // 비트 변수
    private     bool        IsBeat = false;

    private     float       fInterval = 0.25f;
    private     float       fWaitTime = 0.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume -= 0.95f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CheckIsPause()) { return; }

        if ( BeatUpdate(Time.deltaTime) )
        {
            IsBeat = false;

            //Invoke_BeatNode();     //일괄 실행
            WeaponManager.Instance.InvokeEquipItem_Node();

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
            StaticVariable.iBeatAccCount += 1;


            //CreateBeatNode(NodeType.OnlyBeat);

            audioSource.Play();

            return true;
        }

        return false;
    }


    // 내용 : 비트 노드 생성
    private void CreateBeatNode(EnumWeapon e_weapon)
    {
        //GameObject obj = Instantiate( WeaponList.GetBeatNode(e_weapon) );
        //obj.name = obj.name + StaticVariable.iNodeCount;


        //++StaticVariable.iNodeCount;
    }
}


