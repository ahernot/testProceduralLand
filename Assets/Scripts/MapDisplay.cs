using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRenderer;

    public void DrawNoiseMap(float[,] noiseMap)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        // Create linear colourMap array to then apply to the texture
        Color[] colourMap = new Color[width * height];

        // Fill linear colourMap array
        for (int y = 0; y < height; y ++)
        {
            for (int x = 0; x < width; x ++)
            {
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]); // grayscale
            }
        }
        
        // Apply colourMap array to texture
        texture.SetPixels(colourMap);
        texture.Apply();

        // Apply texture
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(width, 1, height); // change plane size
    }
}
