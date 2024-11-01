using UnityEngine;
using UnityEngine.Audio;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //사운드 추가
    private AudioSource audioSource;
    public AudioClip audioClip;

    GameObject obj_Node1, obj_Node2;



    // 비트 변수
    private     bool        IsBeat = false;
    private     int         iBeatAccCount = 0;

    private     float       fInterval = 0.25f;
    private     float       fWaitTime = 0.0f;

    GameObject obj;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obj_Node1 = Resources.Load<GameObject>("Prefab/prefab_Node_1");
        obj_Node2 = Resources.Load<GameObject>("Prefab/prefab_Node_2");

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume -= 0.95f;
    }

    // Update is called once per frame
    void Update()
    {
        if ( BeatUpdate(Time.deltaTime) )
        {
            IsBeat = false;

            switch (iBeatAccCount%8)
            {
                case 0:
                    break;

                case 4:
                    obj = Instantiate(obj_Node1);
                    obj.GetComponent<cs_NodeControl>().Initialize();
                    break;

                case 6:
                    obj = Instantiate(obj_Node2);
                    obj.GetComponent<cs_NodeControl>().Initialize();
                    break;

                default:
                    break;
            }

            print(iBeatAccCount + "Beat!");
        }
    }



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

            audioSource.Play();

            return true;
        }

        return false;
    }




}


