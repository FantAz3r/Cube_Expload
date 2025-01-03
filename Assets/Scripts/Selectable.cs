using System.Reflection;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField] private Painter _painter;

   public void Select()
   {
        GetComponent<Renderer>().material.color = Color.yellow;
   }

    public void Deselect()
    {
        GetComponent<Renderer>().material.color = _painter.Color;
    }
}
