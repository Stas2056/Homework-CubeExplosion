using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
[RequireComponent(typeof(Rigidbody))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _scaleDecrease = 2;
    [SerializeField] private int _spawnChanceDecrease = 2;
    [SerializeField] private int _spawnAmountMin = 2;
    [SerializeField] private int _spawnAmountMax = 6;
    [SerializeField] private Cube _cube;

    public List<Rigidbody> Spawn()
    {
        int minChance = 0;
        int maxChance = 100;

        int spawnRoll = Utils.GenerateRandomNumber(minChance, maxChance);
        int spawnChance = _cube.SpawnChance;

        if (spawnChance >= spawnRoll)
        {
            DecreaseScale(_scaleDecrease);
            int newCubeSpawnChance = spawnChance / _spawnChanceDecrease;
            int spawnAmount = Utils.GenerateRandomNumber(_spawnAmountMin, _spawnAmountMax);

            List<Rigidbody> spawnedCubesRigidbodies = new List<Rigidbody>();

            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject newCubeObject = Instantiate(_cube.gameObject, transform.localPosition,
                                                       Quaternion.identity);

                if (newCubeObject.TryGetComponent(out Cube newCube))
                {
                    newCube.Init(newCubeSpawnChance);

                    if (newCube.TryGetComponent(out Rigidbody newCubeRigidbody))
                    {
                        spawnedCubesRigidbodies.Add(newCubeRigidbody);
                    }
                }
            }

            return spawnedCubesRigidbodies;
        }

        return null;
    }

    private void DecreaseScale(float scaleDecrease)
    {
        transform.localScale /= scaleDecrease;
    }
}