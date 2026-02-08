using UnityEngine;

public class TitleSceneManager : MonoBehaviour
{
    GameLoopManager manager;

    void Awake()
    {
        manager = GameObject.Find("GameLoop").GetComponent<GameLoopManager>();
    }

    public void OnGameStart()
    {
        manager.OnGameStaet();
    }
}
