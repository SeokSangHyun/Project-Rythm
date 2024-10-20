using UnityEngine;

public class GameManager : MonoBehaviour
{
    private cs_MusicPlayManager music = new cs_MusicPlayManager();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
