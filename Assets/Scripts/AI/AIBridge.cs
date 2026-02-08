using AIDrivenFW;
using Cysharp.Threading.Tasks;
using System.IO;
using System.Threading;
using UnityEngine;

public class AIBridge : MonoBehaviour
{
    [SerializeField] GenAIConfig genCityConfig;
    [SerializeField] GenAIConfig reasonConfig;
    string baseData = "";
    [SerializeField] PlaceDatabase placeDatabase;

    private void Start()
    {
        foreach(var place in placeDatabase.placeDatas)
        {
            baseData += $",Id: {place.key} Name：{place.name} Detail：{place.description}";
        }
    }

    /// <summary>
    /// 設置する建物のIDを生成する
    /// </summary>
    /// <parm=input>入力</parm>
    /// <returns>設置する建物のID</returns>
    public async UniTask<int> GenCityGenre(CancellationToken token,string input)
    {
        genCityConfig.arguments = $"--gpu-layers 80 --batch-size 16 --prio 2 --keep 0 -cnv " + $"--grammar-file {Path.Combine(Application.streamingAssetsPath,"Gbnf", "citygen_grammar.gbnf")}";
        genCityConfig.sysPrompt = $"ユーザーの入力した文脈から0以上{placeDatabase.placeDatas.Length - 1}以下で、整数のみを回答して 以降は参考材料です。" + baseData;
        string response = await GenAI.Generate(
            "こんにちは",
            genAIConfig: genCityConfig,
            ct: destroyCancellationToken
        );

        Debug.Log($"[AIBridge] GenCityGenre Response: {response}");

        return int.Parse(response);
    }
}
