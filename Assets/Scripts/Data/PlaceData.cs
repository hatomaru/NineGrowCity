using UnityEngine;

/// <summary>
/// 建物のキーを定義
/// </summary>
public enum PlaceKey
{
    Forest,
    Desert,
}

/// <summary>
/// 建物のデータを定義
/// </summary>
[CreateAssetMenu(fileName = "PlaceData", menuName = "Data/PlaceData")]
public class PlaceData : ScriptableObject
{
    public PlaceKey key;
    public GameObject obj;
    public string name;
}
