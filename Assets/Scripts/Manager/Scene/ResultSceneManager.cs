using TMPro;
using UnityEngine;

public class ResultSceneManager : MonoBehaviour
{
    GameLoopManager manager;
    [SerializeField]TextMeshProUGUI scoreText;

    void Awake()
    {
        manager = GameObject.Find("GameLoop").GetComponent<GameLoopManager>();
    }

    public void Init()
    {
        scoreText.text = $"{GameLoopManager.score * GameLoopManager.bonusMultiplier}";
    }

    public void OnBackClick()
    {
        manager.ChangeStatus(GameState.Title);
    }

    public void OnRetry()
    {
        manager.OnGameStaet();
    }
}
