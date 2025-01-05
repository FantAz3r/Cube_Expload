using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField] private Painter _painter;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    public void Select()
    {
        _renderer.material.color = Color.yellow;
    }

    public void Deselect()
    {
        _renderer.material.color = _painter.Color;
    }
}
