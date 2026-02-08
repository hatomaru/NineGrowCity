using UnityEngine;

/// <summary>
/// 建物のデータを定義
/// </summary>
[CreateAssetMenu(fileName = "EvolutionData", menuName = "Data/EvolutionData")]
public class EvolutionData : ScriptableObject
{
    public PlaceData basePlace;
    public PlaceData resourcePlace;
    public PlaceData toPlace;
    public string reason;
}
