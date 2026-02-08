using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    public const int kMaxTurn = 9;

    [SerializeField] UILayerManager uILayerManager;
    [SerializeField] AIBridge aiBridge;
    [SerializeField] CityManager cityManager;
    [SerializeField] GrowSceneManager growSceneManager;
    [SerializeField] HUDObjectManager hudManager;
    [SerializeField] PlaceDatabase placeDatabase;
    [SerializeField] AskSceneManager askSceneManager;
    [SerializeField] ResultSceneManager resultSceneManager;

    public static int score = 0;
    public static float bonusMultiplier = 1;
    public static int turn = 2;

    public static int beforeScore = 0;
    public static float beforeBonusMultiplier = 1;

    int setGenre = 0;

    void Start()
    {
        // 初期状態をタイトルに設定
        ChangeStatus(GameState.Title);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"現在は{StateManager.status.ToString()}です。");
        switch (StateManager.status)
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
    /// ゲーム開始時の処理
    /// </summary>
    public async void OnGameStaet()
    {
        // ゲーム開始時の初期化処理
        turn = 1;
        score = 0;
        bonusMultiplier = 1;
        beforeBonusMultiplier = 0;
        beforeScore = 0;
        hudManager.RefreshUI();

        uILayerManager.AllOffUILayer();
        uILayerManager.OnUILayer(UILayer.HUD);
        await cityManager.AllHideCity(destroyCancellationToken);
        ChangeStatus(GameState.Ask);
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
                askSceneManager.Init();
                uILayerManager.OnUILayer(UILayer.Ask);
                break;
            case GameState.Generate:
                // 生成画面に切り替えたときの処理                
                uILayerManager.OffUILayer(UILayer.Ask);
                uILayerManager.OnUILayer(UILayer.Generate);
                setGenre = await aiBridge.GenCityGenre(destroyCancellationToken, askSceneManager.GetInput());
                // 街を生成
                await cityManager.GenCity(destroyCancellationToken, placeDatabase.GetPlaceData((PlaceKey)setGenre));
                ToNextStatus();
                break;
            case GameState.Grow:
                // 成長画面に切り替えたときの処理
                uILayerManager.OffUILayer(UILayer.Generate);
                await growSceneManager.GrowLoop(destroyCancellationToken);
                ToNextStatus();
                break;
            case GameState.Result:
                // 結果画面に切り替えたときの処理
                resultSceneManager.Init();
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
                // 成長フェーズが終了したら、ターン数に応じて結果画面か次のターンへ移行
                if (turn >= kMaxTurn)
                {
                    ChangeStatus(GameState.Result);
                }
                else
                {
                    turn++;
                    ChangeStatus(GameState.Ask);
                }
                break;
            case GameState.Result:
                ChangeStatus(GameState.Title);
                break;
        }
    }
}
