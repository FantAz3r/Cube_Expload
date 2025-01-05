using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Cube parentCube, List<Cube> createdCubes)
    {
        foreach (Cube cube in createdCubes)
        {
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                Vector3 explosionDirection = (cube.transform.position - parentCube.transform.position).normalized;
                rigidbody.AddForce(explosionDirection * _explosionForce, ForceMode.Impulse);
            }
        }
    }
}
