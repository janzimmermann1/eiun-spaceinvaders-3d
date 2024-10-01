using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(LowPolyGenerator))]
public class TerrainGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LowPolyGenerator script = (LowPolyGenerator) target;
        
        if(DrawDefaultInspector())
        {
            script.Initiate();
        }

        if (GUILayout.Button("New Seed"))
        {
            script.seed = Random.Range(0, 100);
            script.Initiate();
        }

        if (GUILayout.Button("Save Mesh as Asset"))
        {
            script.SaveMesh();
        }
    }
}
