using UnityEngine;

public class Cube : MonoBehaviour
{
    public int SeparationChance { get; private set; } = 100;

    public int SetSeparationChance(int separationChance)
    {
        SeparationChance = separationChance;
        return SeparationChance;
    }
}
