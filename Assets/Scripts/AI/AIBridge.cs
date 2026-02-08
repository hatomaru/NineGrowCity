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
        foreach (var place in placeDatabase.placeDatas)
        {
            baseData +=
    $@"
[{place.key}]
説明: {place.description}
";
        }
    }

    /// <summary>
    /// 設置する建物のIDを生成する
    /// </summary>
    /// <parm=input>入力</parm>
    /// <returns>設置する建物のID</returns>
    public async UniTask<int> GenCityGenre(CancellationToken token,string input)
    {
        genCityConfig.arguments = $"--gpu-layers 80 --batch-size 32 --prio 2 --keep 0 -cnv --temp 1.1 --top-p 0.8 " + $"--grammar-file {Path.Combine(Application.streamingAssetsPath,"Gbnf", "citygen_grammar.gbnf")}";
        genCityConfig.sysPrompt = $"あなたは分類器です。ユーザーの入力文を読み、以下の建物候補の中から、意味的に最も近い建物IDを1つ選びます。\r\n\r\n# 建物候補" + baseData;
        string response = await GenAI.Generate(
            input,
            genAIConfig: genCityConfig,
            ct: destroyCancellationToken
        );

        Debug.Log($"[AIBridge] GenCityGenre Response: {response}");

        return int.Parse(response);
    }

    /// <summary>
    /// 理由を生成する
    /// </summary>
    /// <parm=input>入力</parm>
    /// <returns>理由のテキスト</returns>
    public async UniTask<string> GenReasone(CancellationToken token, string input)
    {
        reasonConfig.sysPrompt = $"You are an observer AI describing the result of city growth.Do not explain. Just comment briefly.";
        string response = await GenAI.Generate(
            input,
            genAIConfig: reasonConfig,
            ct: destroyCancellationToken
        );

        Debug.Log($"[AIBridge] GenCityGenre Response: {response}");

        return response;
    }
}
