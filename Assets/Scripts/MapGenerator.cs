using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Values defining the map
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    [Range(0,1)] // creates slider
    public float persistence;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate; // auto update on settings change

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistence, lacunarity, offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }


    // Method called whenever one of the variables is changed in the inspector
    void OnValidate()
    {
        // Clamp mapWidth
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }

        // Clamp mapHeight
        if (mapHeight < 1)
        {
            mapHeight = 1;
        }

        // Clamp lacunarity
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }

        // Clamp octaves
        if (octaves < 0)
        {
            octaves = 0;
        }

    }
}
