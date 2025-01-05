using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _spawnObjectPrefab;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private int _minSpawnAmount = 2;
    [SerializeField] private int _maxSpawnAmount = 6;
    [SerializeField] private float _explosiveForceFactor = 1.5f;
    [SerializeField] private float _explosiveRadiusFactor = 1.5f;

    private void Start()
    {
        foreach (Transform spawnPoint in _spawnPoints)
        {
            Cube cube = Instantiate(_spawnObjectPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
    
    public void Create(Cube parentCube)
    {
        int reduceValue = 2;
        int spawnAmount = Random.Range(_minSpawnAmount, _maxSpawnAmount + 1);

        List<Cube> createdCubes = new List<Cube>();

        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 randomOffset = new Vector3(
               Random.Range(-1f, 1f),
               Random.Range(-1f, 1f),
               Random.Range(-1f, 1f)
           ).normalized * Random.Range(0.5f, 1f);

            Cube cube = Instantiate(_spawnObjectPrefab, parentCube.transform.position + randomOffset, Quaternion.identity);
            cube.transform.localScale = parentCube.transform.localScale / reduceValue;
            cube.SetSeparationChance(parentCube.SeparationChance / reduceValue);
            cube.SetExplosionForce(parentCube.ExplosionForce * _explosiveForceFactor);
            cube.SetExplosionRadius(parentCube.ExplosionRadius * _explosiveRadiusFactor);
            createdCubes.Add(cube);
        }
    }
}
