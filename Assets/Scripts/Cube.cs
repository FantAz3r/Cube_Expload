using UnityEngine;

public class Cube : MonoBehaviour
{
    public int SeparationChance { get; private set; } = 100;

    public void SetSeparationChance(int separationChance)
    {
        SeparationChance = separationChance;
    }
}
