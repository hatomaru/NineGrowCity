using UnityEngine;

/// <summary>
/// ゲーム状態の定義
/// </summary>
public enum GameState
{
    Title,
    Ask,
    Generate,
    Grow,
    Result
}

public class StateManager : MonoBehaviour
{
    public static GameState status { private set; get; } = GameState.Title;

    public static void ChangeState(GameState newState)
    {
        status = newState;
        Debug.Log($"Game state changed to: {status}");
    }
}
