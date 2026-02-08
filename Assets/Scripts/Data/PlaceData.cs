using UnityEngine;

/// <summary>
/// 建物のキーを定義
/// </summary>
public enum PlaceKey
{
    Ferris_wheel, Ice_city, Beach, Coal, Castle_town, Live_venue, Construction_site, Cargo_area, Dining_table, Dungeon, Farm, Forest, Golf_course, Island, Jurassic, Campsite, Oasis, Office, Palace, Racetrack, Ranch, Sci_fi, Sea, Ski_slope, Moon_surface, Railway_tracks, Station, Tropical_island, UFO, Wedding_venue, Western_town
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
    public string data;
    public string description;
    public int pointValue;
}
