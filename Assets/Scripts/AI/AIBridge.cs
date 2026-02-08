using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class AIBridge : MonoBehaviour
{
    /// <summary>
    /// 設置する建物のIDを生成する
    /// </summary>
    /// <returns>設置する建物のID</returns>
    public async UniTask<string> GenCityGenre(CancellationToken token)
    {
        await UniTask.Delay(1000, cancellationToken: token); // 擬似的な非同期処理
        return "FantasyCity";
    }
}
