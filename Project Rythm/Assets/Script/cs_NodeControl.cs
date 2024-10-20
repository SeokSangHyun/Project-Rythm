using UnityEngine;
using UnityEngine.UI;

public class cs_Node1 : MonoBehaviour
{
    private float               speed               = 100;
    private RectTransform       rectTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);
    }



    void OnButtonClick()
    {
        Destroy(gameObject);
    }
}
