using UnityEngine;
using UnityEditor;


public class ExampleWindow : EditorWindow
{
    Color color;

    [MenuItem("Window/Colorized")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Colorized");
    }

    void OnGUI()
    {

        GUILayout.Label("Change the color of the selected gameobject", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);

        if (GUILayout.Button("COLORIZE!!"))
        {
            Colorized();
        }
    }

    private void Colorized()
    {
        foreach (GameObject gameobj in Selection.gameObjects)
        {
            Renderer rend = gameobj.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.sharedMaterial.color = color;
            }
        }
    }
}
