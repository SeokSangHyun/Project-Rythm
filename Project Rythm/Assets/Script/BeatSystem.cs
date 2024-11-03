using UnityEngine;
using UnityEngine.Audio;

public class BeatSystem : MonoBehaviour
{
    //���� �߰�
    private AudioSource audioSource;
    public AudioClip audioClip;

    GameObject              obj_BeatNode;
    GameObject              prefab_BeatNode;
    GameObject              obj_Node1, obj_Node2;
    GameObject              obj;


    // ��Ʈ ����
    private     bool        IsBeat = false;
    private     int         iBeatAccCount = 0;

    private     float       fInterval = 0.25f;
    private     float       fWaitTime = 0.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�⺻ ��Ʈ ǥ��
        prefab_BeatNode = Resources.Load<GameObject>("Prefab/prefab_BeatNode_Arrow");

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
                    obj.GetComponent<csNodeControl>().Initialize();
                    break;

                case 6:
                    obj = Instantiate(obj_Node2);
                    obj.GetComponent<csNodeControl>().Initialize();
                    break;

                default:
                    break;
            }

            //print(iBeatAccCount + "Beat!");
        }
    }



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

            obj_BeatNode = Instantiate(prefab_BeatNode);
            obj_BeatNode.GetComponent<csNodeControl>().Initialize();

            audioSource.Play();

            return true;
        }

        return false;
    }




}


