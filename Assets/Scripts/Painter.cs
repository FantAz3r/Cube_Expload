using UnityEngine;

public class Painter : MonoBehaviour
{
    public Color Color { get; private set; }


    private void OnEnable()
    {
        Color = Random.ColorHSV();
        GetComponent<Renderer>().material.color = Color;
    }
}
