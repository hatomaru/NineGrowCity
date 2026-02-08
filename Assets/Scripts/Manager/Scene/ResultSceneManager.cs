using UnityEngine;

public class ResultSceneManager : MonoBehaviour
{
    GameLoopManager manager;

    void Awake()
    {
        manager = GameObject.Find("GameLoop").GetComponent<GameLoopManager>();
    }

    public void OnBackClick()
    {
        manager.ChangeStatus(GameState.Title);
    }
}
