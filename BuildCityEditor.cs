using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildCity)), CanEditMultipleObjects]
public class BuildCityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        BuildCity cityBuilder = (BuildCity)target;
        if (GUILayout.Button("Generate Cities"))
        {
            Undo.RecordObject(target, "Generation");
            cityBuilder.ClearCities(); //clear all prefabs before generating again
            cityBuilder.GenerateCity();
        }

        if (GUILayout.Button("Clear"))
        {
            cityBuilder.ClearCities();
        }
    }
}
