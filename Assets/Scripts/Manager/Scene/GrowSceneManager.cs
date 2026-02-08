using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class GrowSceneManager : MonoBehaviour
{
    GameLoopManager manager;
    [SerializeField]CityManager cityManager;
    [SerializeField]PlaceDatabase placeDatabase;

    void Awake()
    {
        manager = GameObject.Find("GameLoop").GetComponent<GameLoopManager>();
    }

    /// <summary>
    /// 成長ループ
    /// </summary>
    /// <returns></returns>
    public async UniTask GrowLoop(CancellationToken token)
    {
        bool isGrowing = true;
        // 成長処理ループ
        while (isGrowing)
        {
            isGrowing = false;
            for (int i = 0; i < cityManager.cityPlaces.Length; i++)
            {
                Debug.Log($"{i + 1}回目の成長を開始します。");
                if (true)
                {
                    // 成長処理
                    await cityManager.GrowCity(token, i, placeDatabase.GetPlaceData(PlaceKey.Forest));
                    Debug.Log($"{i + 1}回目の成長が完了しました。");
                    isGrowing = true;
                    await UniTask.Delay(150, cancellationToken: token);
                }
            }
            isGrowing = false;
            await UniTask.Delay(500, cancellationToken: token);
        }
    }
}
