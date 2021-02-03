using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise // static because no need for multiple instances of this script
{
    // returns a 2D array of floats
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale)
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        // Clamp scale to avoid errors
        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        for (int y = 0; y < mapHeight; y ++)
        {
            for (int x = 0; x < mapWidth; x ++)
            {
                float sampleX = x / scale;
                float sampleY = y / scale;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x, y] = perlinValue; // apply to noiseMap
            }
        }

        return noiseMap;
    }
}
