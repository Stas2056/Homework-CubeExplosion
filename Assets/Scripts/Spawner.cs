using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private int _startCubeCount = 3;

    private void Start()
    {
        SpawnFirstCubes();
    }

    public List<Rigidbody> Spawn(Cube cube, int spawnAmount, int spawnChance, float scaleDecrease)
    {
        List<Rigidbody> spawnedCubesRigidbodies = new List<Rigidbody>();

        for (int i = 0; i < spawnAmount; i++)
        {
            Cube newCube = Instantiate(cube, RandomIndent(cube.transform.position), cube.transform.rotation);
            newCube.Init(spawnChance, scaleDecrease);
            spawnedCubesRigidbodies.Add(newCube.Rigidbody);
            newCube.Clicked += DisableCube;
        }

        return spawnedCubesRigidbodies;
    }

    private Vector3 RandomIndent(Vector3 position)
    {
        position.y += RandomOne();
        position.x += RandomOne();
        position.z += RandomOne();

        return position;
    }

    private Vector3 RandomIndent()
    {
        Vector3 position = Vector3.zero;
        position.y += RandomOne();
        position.x += RandomOne();
        position.z += RandomOne();

        return position;
    }

    private int RandomOne()
    {
        int minValue = -1;
        int maxValue = 1;

        return Random.Range(minValue, maxValue);
    }

    private void DisableCube(Cube cube)
    {
        cube.Clicked -= DisableCube;
        Destroy(cube.gameObject);
    }

    private void SpawnFirstCubes()
    {
        int spawnChance = 100;
        int scaleDecrease = 1;

        for (int i = 0; i < _startCubeCount; i++)
        {
            Cube cube = Instantiate(_cube, RandomIndent(), Quaternion.identity);
            cube.Init(spawnChance, scaleDecrease);
            cube.Clicked += DisableCube;
        }
    }
}