using UnityEngine;

public class PlaceDatabase : MonoBehaviour
{
    public PlaceData[] placeDatas;

    /// <summary>
    /// 指定したキーに対応する建物データを取得する
    /// </summary>
    /// <param name="key">検索したいキー</param>
    /// <returns>検索結果</returns>
    public PlaceData GetPlaceData(PlaceKey key)
    {
        foreach (var data in placeDatas)
        {
            if (data.key == key)
            {
                return data;
            }
        }
        Debug.LogError($"PlaceData not found for key: {key}");
        return null;
    }
}
