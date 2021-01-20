using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cube))]
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Cube cube = (Cube)target;

        GUILayout.Label("Size of the Cube");

        cube.size = EditorGUILayout.Slider("Size Cube: " , cube.size , 0.1f , 2f);

        cube.transform.localScale = Vector3.one * cube.size;

        GUILayout.BeginHorizontal();

            if (GUILayout.Button("Generate Color"))
            {
                cube.GenerateColor();
            }

            if (GUILayout.Button("Reset"))
            {
                cube.Reset();
            }

        GUILayout.EndHorizontal();
    }
}
