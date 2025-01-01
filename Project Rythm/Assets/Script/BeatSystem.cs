using UnityEngine;
using UnityEngine.Audio;

public class BeatSystem : MonoBehaviour
{
    //���� �߰�
    private AudioSource audioSource;
    public AudioClip audioClip;


    // ��Ʈ ����
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

            //Invoke_BeatNode();     //�ϰ� ����
            WeaponManager.Instance.InvokeEquipItem_Node();

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


    // ���� : ��Ʈ ��� ����
    private void CreateBeatNode(EnumWeapon e_weapon)
    {
        //GameObject obj = Instantiate( WeaponList.GetBeatNode(e_weapon) );
        //obj.name = obj.name + StaticVariable.iNodeCount;


        //++StaticVariable.iNodeCount;
    }
}


