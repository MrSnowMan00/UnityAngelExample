using UnityEngine;

public class Cube : MonoBehaviour
{
    [HideInInspector]
    public float size;

    void Start()
    {
        GenerateColor();
    }

    //
    //  Summary:
    //      This is gonna make a new random color for the gameobject.
    public void GenerateColor()
    {
        GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
    }

    public void Reset()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.white;
    }

}
