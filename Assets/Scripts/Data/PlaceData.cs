using UnityEngine;

/// <summary>
/// 土地のキーを定義
/// </summary>
public enum PlaceKey
{
    Forest,
    Desert,
}

/// <summary>
/// 土地のデータを定義
/// </summary>
[CreateAssetMenu(fileName = "PlaceData", menuName = "Data/PlaceData")]
public class PlaceData : ScriptableObject
{
    public PlaceKey key;
    public GameObject obj;
    public string name;
}
