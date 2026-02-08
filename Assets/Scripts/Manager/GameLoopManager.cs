using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    [SerializeField] UILayerManager uILayerManager;
    [SerializeField] AIBridge aiBridge;

    void Start()
    {
        // 初期状態をタイトルに設定
        ChangeStatus(GameState.Title);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"現在は{StateManager.status.ToString()}です。");
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
    public async void ChangeStatus(GameState gameState)
    {
        StateManager.ChangeState(gameState);
        switch (gameState)
        {
            case GameState.Title:
                // 全てのUIレイヤーを非表示にする
                uILayerManager.AllOffUILayer();
                uILayerManager.OnUILayer(UILayer.Title);
                break;
            case GameState.Ask:
                Debug.Log("質問画面に切り替えます。");
                // 質問画面に切り替えたときの処理
                uILayerManager.OffUILayer(UILayer.Title);
                uILayerManager.OnUILayer(UILayer.Ask);
                break;
            case GameState.Generate:
                // 生成画面に切り替えたときの処理                
                uILayerManager.OffUILayer(UILayer.Ask);
                uILayerManager.OnUILayer(UILayer.Generate);
                await aiBridge.GenCityGenre(destroyCancellationToken);
                ToNextStatus();
                break;
            case GameState.Grow:
                // 成長画面に切り替えたときの処理
                uILayerManager.OffUILayer(UILayer.Generate);
                break;
            case GameState.Result:
                // 結果画面に切り替えたときの処理
                uILayerManager.OnUILayer(UILayer.Result);
                break;
        }
    }

    /// <summary>
    /// 次の状態に移行する
    /// </summary>
    public void ToNextStatus()
    {
        Debug.Log("次の状態に移行します。" + StateManager.status.ToString());
        switch (StateManager.status)
        {
            case GameState.Title:
                ChangeStatus(GameState.Ask);
                break;
            case GameState.Ask:
                ChangeStatus(GameState.Generate);
                break;
            case GameState.Generate:
                ChangeStatus(GameState.Grow);
                break;
            case GameState.Grow:
                ChangeStatus(GameState.Result);
                break;
            case GameState.Result:
                ChangeStatus(GameState.Title);
                break;
        }
    }
}
