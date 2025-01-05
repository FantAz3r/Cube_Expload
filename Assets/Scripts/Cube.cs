using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] public float ExplosionForce { get; private set; } = 100;
    [SerializeField] public float ExplosionRadius { get; private set; } = 20;

    public int SeparationChance { get; private set; } = 100;
    
    public int SetSeparationChance(int separationChance)
    {
        SeparationChance = separationChance;
        return SeparationChance;
    }

    public float SetExplosionForce(float explosionForce)
    {
        ExplosionForce = explosionForce;
        return ExplosionForce;
    }

    public float SetExplosionRadius(float explosionRadius)
    {
        ExplosionRadius = explosionRadius;
        return ExplosionRadius;
    }
}
