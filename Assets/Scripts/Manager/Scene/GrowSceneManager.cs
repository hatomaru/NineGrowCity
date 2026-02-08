using Cysharp.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GrowSceneManager : MonoBehaviour
{
    GameLoopManager manager;
    [SerializeField]CityManager cityManager;
    [SerializeField]PlaceDatabase placeDatabase;
    [SerializeField]HUDObjectManager hudManager;
    [SerializeField] AIBridge aiBridge;
    [SerializeField] NotificationManager notification;
    [SerializeField] EvolutionDatabase evolutionDatabase;

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
                // 成長判定
                EvolutionData nextPlace = GetGrowPlace(i);
                if (nextPlace != null)
                {
                    // 成長処理
                    GameLoopManager.score += 100;
                    GameLoopManager.bonusMultiplier += 0.1f;
                    hudManager.RefreshUI();
                    string reaason = await aiBridge.GenReasone(token, $"{nextPlace.reason}.");
                    notification.Run(reaason);
                    GameLoopManager.score -= nextPlace.basePlace.pointValue;
                    GameLoopManager.score += nextPlace.toPlace.pointValue;
                    GameLoopManager.bonusMultiplier += nextPlace.ava;
                    hudManager.RefreshUI();
                    await cityManager.GrowCity(token, i, nextPlace.toPlace);
                    Debug.Log($"{i + 1}回目の成長が完了しました。");
                    isGrowing = true;
                    await UniTask.Delay(150, cancellationToken: token);
                }
            }
            await UniTask.Delay(500, cancellationToken: token);
        }
    }

    /// <summary>
    /// 進化後の建物データを取得する
    /// </summary>
    /// <param name="index">土地インデックス</param>
    /// <returns>進化後の建物データ</returns>
    public EvolutionData GetGrowPlace(int index)
    {
        PlaceData currentPlace = cityManager.cityPlaces[index].placeData;
        List<PlaceData> CheckPlaceList = new List<PlaceData>();
        int setindex = index + 1;
        // 順番に周囲の建物データを取得
        if (cityManager.isEnableArea(setindex))
        {
            if(cityManager.cityPlaces[setindex].placeData != null)
            {
                CheckPlaceList.Add(cityManager.cityPlaces[setindex].placeData);
            }
        }
        setindex = index + 4;
        if (cityManager.isEnableArea(setindex))
        {
            if (cityManager.cityPlaces[setindex].placeData != null)
            {
                CheckPlaceList.Add(cityManager.cityPlaces[setindex].placeData);
            }
        }
        setindex = index - 4;
        if (cityManager.isEnableArea(setindex))
        {
            if (cityManager.cityPlaces[setindex].placeData != null)
            {
                CheckPlaceList.Add(cityManager.cityPlaces[setindex].placeData);
            }
        }
        setindex = index - 1;
        if (cityManager.isEnableArea(setindex))
        {
            if (cityManager.cityPlaces[setindex].placeData != null)
            {
                CheckPlaceList.Add(cityManager.cityPlaces[setindex].placeData);
            }
        }
        if(CheckPlaceList.Count <= 0)
        {
            // 周囲に建物がない場合は進化しない
            return null;
        }
        // 進化条件を満たす建物があるか確認
        foreach(var evoData in evolutionDatabase.evolutionDatas)
        {
            if(evoData.basePlace == currentPlace)
            {
                bool isMatch = true;
                foreach(var reqPlace in CheckPlaceList)
                {
                    if(!CheckPlaceList.Contains(evoData.resourcePlace))
                    {
                        isMatch = false;
                        break;
                    }
                }
                if(isMatch)
                {
                    return evoData;
                }
            }
        }
        return null;
    }
}
