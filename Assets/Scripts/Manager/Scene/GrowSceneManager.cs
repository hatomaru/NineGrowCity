using UnityEngine;

public class GrowSceneManager : MonoBehaviour
{
    GameLoopManager manager;

    void Awake()
    {
        manager = GameObject.Find("GameLoop").GetComponent<GameLoopManager>();
    }
}
