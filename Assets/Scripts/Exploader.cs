using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Cube parentCube)
    {
        foreach (Rigidbody explodbleCubes in GetExplodbleCubes( parentCube))
        {
            explodbleCubes.AddExplosionForce(parentCube.ExplosionForce, parentCube.transform.position, parentCube.ExplosionRadius);
        }
    }

    private List<Rigidbody> GetExplodbleCubes(Cube parentCube)
    {
        Collider[] hits = Physics.OverlapSphere(parentCube.transform.position, parentCube.ExplosionRadius);
        List<Rigidbody> cubes = new();
        
        foreach(Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
