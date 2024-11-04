using UnityEngine;
using UnityEngine.Audio;
using static TreeEditor.TreeEditorHelper;

public class BeatSystem : MonoBehaviour
{
    //사운드 추가
    private AudioSource audioSource;
    public AudioClip audioClip;

    GameObject              obj_BeatNode;
    GameObject              prefab_BeatNode;
    GameObject              prefab_Node1, obj_Node2;
    GameObject              obj;


    // 비트 변수
    private     bool        IsBeat = false;
    private     int         iBeatAccCount, iNodeCount = 0;

    private     float       fInterval = 0.25f;
    private     float       fWaitTime = 0.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //기본 비트 표시
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

            CreateBeatNode(NodeType.OnlyBeat);

            audioSource.Play();

            return true;
        }

        return false;
    }


    // 내용 : 비트 노드 생성
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


