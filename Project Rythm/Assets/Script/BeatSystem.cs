using UnityEngine;
using UnityEngine.Audio;
using static TreeEditor.TreeEditorHelper;

public class BeatSystem : MonoBehaviour
{
    //���� �߰�
    private AudioSource audioSource;
    public AudioClip audioClip;

    GameObject              obj_BeatNode;
    GameObject              prefab_BeatNode;
    GameObject              prefab_Node1, obj_Node2;
    GameObject              obj;


    // ��Ʈ ����
    private     bool        IsBeat = false;
    private     int         iBeatAccCount, iNodeCount = 0;

    private     float       fInterval = 0.25f;
    private     float       fWaitTime = 0.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�⺻ ��Ʈ ǥ��
        prefab_BeatNode = Resources.Load<GameObject>("Prefab/prefab_BeatNode_Arrow");

        prefab_Node1 = Resources.Load<GameObject>("Prefab/prefab_Node_1");
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
                    CreateBeatNode(NodeType.Normal);
                    break;

                case 6:
                    CreateBeatNode(NodeType.Normal);
                    break;

                default:
                    break;
            }

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

            CreateBeatNode(NodeType.OnlyBeat);

            audioSource.Play();

            return true;
        }

        return false;
    }


    // ���� : ��Ʈ ��� ����
    private void CreateBeatNode(NodeType nodeType)
    {
        GameObject obj;

        if (nodeType == NodeType.OnlyBeat)
        {
            obj = Instantiate(prefab_BeatNode);
            obj.name = prefab_BeatNode.name + iNodeCount;
            obj.GetComponent<csNodeControl>().Initialize();
        }
        else if (nodeType == NodeType.Normal)
        {
            obj = Instantiate(prefab_Node1);
            obj.name = prefab_Node1.name + iNodeCount;
            obj.GetComponent<csNodeControl>().Initialize();
        }
        else
        {
            --iNodeCount;
        }



        ++iNodeCount;
    }
}


