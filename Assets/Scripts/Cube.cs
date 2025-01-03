using System.Collections.Generic;
using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int _separationChance { get; private set; } = 100;
 
    public event Action Destroed;

    public void Destroy()
    {
        Destroed?.Invoke();
    }

    public void SetSeparationChance(int separationChance)
    {
        _separationChance = separationChance;
    }
}
