using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _spawnObjectPrefab;
    [SerializeField] private int _minSpawnAmount = 2;
    [SerializeField] private int _maxSpawnAmount = 6;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float explosionForce = 5f;
    [SerializeField] private ParticleSystem _effect;

    private void Start()
    {
        foreach (Transform spawnPoint in _spawnPoints)
        {
            Cube cube = Instantiate(_spawnObjectPrefab, spawnPoint.position, Quaternion.identity);
            cube.Destroed += CubeDestroed; 
        }
    }

    private void CubeDestroed()
    {
        
    }
    
    public void Create(Cube parentCube)
    {
        int reduceValue = 2;
        int minChance = 0;
        int maxChance = 100;

        int spawnAmount = Random.Range(_minSpawnAmount, _maxSpawnAmount + 1);

        if (parentCube._separationChance > Random.Range(minChance, maxChance+1))
        {
            List<Cube> createdCubes = new List<Cube>();

            for (int i = 0; i < spawnAmount; i++)
            {
                Cube cube = Instantiate(_spawnObjectPrefab, parentCube.transform.position, Quaternion.identity);
                cube.transform.localScale = parentCube.transform.localScale / reduceValue;
                cube.SetSeparationChance(parentCube._separationChance / reduceValue);
                cube.Destroed += CubeDestroed;
                createdCubes.Add(cube);
            }

            Explode(parentCube, createdCubes);
        }
    }

    private void Explode(Cube parentCube, List<Cube> createdCubes)
    {
       
        foreach (Cube cube in createdCubes)
        {
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                Vector3 explosionDirection = (cube.transform.position - parentCube.transform.position).normalized;
                rigidbody.AddForce(explosionDirection * explosionForce, ForceMode.Impulse);
            }
        }
    }
}
