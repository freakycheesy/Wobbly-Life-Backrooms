using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class TerrainFixer : MonoBehaviour
{
    public TerrainData data;
    public int HeightmapResolution;
    public int AlphamapResolution;
    public int DetailedResolution;
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!data) return;
        HeightmapResolution = data.heightmapResolution;
        AlphamapResolution = data.alphamapResolution;
        DetailedResolution = data.detailResolution;
    }
#endif
    void Start()
    {
        TerrainData terrainData = Instantiate(data);
        terrainData.heightmapResolution = HeightmapResolution;
        terrainData.alphamapResolution = AlphamapResolution;
        terrainData.SetDetailResolution(DetailedResolution, 16);
    }
}
