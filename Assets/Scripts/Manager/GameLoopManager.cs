using UnityEngine;

public class GameLoopManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        switch(StateManager.status)
        {
            case GameState.Title:
                // タイトル画面の処理
                break;
            case GameState.Ask:
                // 質問画面の処理
                break;
            case GameState.Generate:
                // 生成画面の処理
                break;
            case GameState.Grow:
                // 成長画面の処理
                break;
            case GameState.Result:
                // 結果画面の処理
                break;
        }
    }

    /// <summary>
    /// 状態切り替え時に処理を行う
    /// </summary>
    /// <param name="gameState">変更後の状態</param>
    public void ChangeStatus(GameState gameState)
    {
        switch(gameState)
        {
            case GameState.Title:
                // タイトル画面に切り替えたときの処理
                break;
            case GameState.Ask:
                // 質問画面に切り替えたときの処理
                break;
            case GameState.Generate:
                // 生成画面に切り替えたときの処理
                break;
            case GameState.Grow:
                // 成長画面に切り替えたときの処理
                break;
            case GameState.Result:
                // 結果画面に切り替えたときの処理
                break;
        }
    }
}
