using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _scaleDecrease = 2;
    [SerializeField] private int _spawnChanceDecrease = 2;
    [SerializeField] private int _spawnAmountMin = 2;
    [SerializeField] private int _spawnAmountMax = 6;

    public List<Rigidbody> Spawn(Cube cube)
    {
        int minChance = 0;
        int maxChance = 100;

        int spawnRoll = Utils.GenerateRandomNumber(minChance, maxChance);
        int spawnChance = cube.SpawnChance;

        if (spawnChance >= spawnRoll)
        {
            int newCubeSpawnChance = spawnChance / _spawnChanceDecrease;
            int spawnAmount = Utils.GenerateRandomNumber(_spawnAmountMin, _spawnAmountMax);

            List<Rigidbody> spawnedCubesRigidbodies = new List<Rigidbody>();

            for (int i = 0; i < spawnAmount; i++)
            {
                Cube newCube = Instantiate(cube, cube.transform.localPosition, cube.transform.rotation);
                newCube.Init(newCubeSpawnChance, _scaleDecrease);
                spawnedCubesRigidbodies.Add(newCube.Rigidbody);
            }

            return spawnedCubesRigidbodies;
        }

        return null;
    }
}