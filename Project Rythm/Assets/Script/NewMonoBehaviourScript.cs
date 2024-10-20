using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject MainUI;
    GameObject obj_Node;

    float WaitTime = 0.0f;
    float Interval = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obj_Node = Resources.Load<GameObject>("Prefab/prefab_Node");
    }

    // Update is called once per frame
    void Update()
    {
        WaitTime += Time.deltaTime;

        if ( WaitTime >= Interval )
        {
            print("»ý¼º");
            GameObject obj = Instantiate(obj_Node);
            obj.transform.parent = MainUI.transform;

            RectTransform rect = obj.GetComponent<RectTransform>();
            rect.anchoredPosition = Vector2.zero;
            WaitTime = 0.0f;
        }

    }
}