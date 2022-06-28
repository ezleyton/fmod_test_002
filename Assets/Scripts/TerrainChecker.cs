using UnityEngine;

//TODO: CHECK THIS https://www.youtube.com/watch?v=wXcjxeetg70
public class TerrainChecker
{
    private float[] GetTextureData(Vector3 playerPosition, Terrain terrain)
    {
        Vector3 terrainPosition = terrain.transform.position;

        TerrainData terrainData = terrain.terrainData;
        int mapX = Mathf.RoundToInt((playerPosition.x - terrainPosition.x) / terrainData.size.x *
                                    terrainData.alphamapWidth);
        
        int mapZ = Mathf.RoundToInt((playerPosition.z - terrainPosition.z) / terrainData.size.z *
                                    terrainData.alphamapHeight);

        float[,,] splatMapData = terrainData.GetAlphamaps(mapX, mapZ, 1, 1);

        float[] cellmix = new float[splatMapData.GetUpperBound(2) + 1];

        for (int i = 0; i < cellmix.Length; i++)
        {
            cellmix[i] = splatMapData[0, 0, i];
        }

        return cellmix;
    }

    public string GetLayerName(Vector3 playerPosition, Terrain terrain)
    {
        float[] cellmix = GetTextureData(playerPosition, terrain);
        float strongest = 0;
        int maxIndex = 0;

        for (int i = 0; i < cellmix.Length; i++)
        {
            if (cellmix[i] > strongest)
            {
                maxIndex = i;
                strongest = cellmix[i];
            }
        }

        return terrain.terrainData.terrainLayers[maxIndex].name;
    }
 }
