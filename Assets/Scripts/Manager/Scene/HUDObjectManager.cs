using DG.Tweening;
using TMPro;
using UnityEngine;

public class HUDObjectManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bonusMultiplierText;

    // Update is called once per frame
    void Update()
    {
        turnText.text = $"{GameLoopManager.turn}<size=50>/{GameLoopManager.kMaxTurn}";
    }

    public void RefreshUI()
    {
        DOVirtual.Int(GameLoopManager.beforeScore, GameLoopManager.score, 0.2f, (int value) =>
        {
            GameLoopManager.beforeScore = value;
            scoreText.text = $"{value}";
        });
        DOVirtual.Float(GameLoopManager.beforeBonusMultiplier, GameLoopManager.bonusMultiplier, 0.2f, (float value) =>
        {
            GameLoopManager.beforeBonusMultiplier = value;
            bonusMultiplierText.text = $"x{value:F1}";
        });
    }
}
