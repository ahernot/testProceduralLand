using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (MapGenerator))]
public class MapGeneratorEditor : Editor
{
    // Override default inspector
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target; // cast to a MapGenerator object

        if (DrawDefaultInspector ())
        {
            // Auto update
            if (mapGen.autoUpdate)
            {
                mapGen.GenerateMap ();
            }
        }

        if (GUILayout.Button ("Generate"))
        {
            mapGen.GenerateMap ();
        }

    }
}
