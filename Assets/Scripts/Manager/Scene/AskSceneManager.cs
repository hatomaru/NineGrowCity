using UnityEngine;

public class AskSceneManager : MonoBehaviour
{
    GameLoopManager manager;

    void Awake()
    {
        manager = GameObject.Find("GameLoop").GetComponent<GameLoopManager>();
    }

    public void OnClick()
    {
        manager.ToNextStatus();
    }
}
