using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Cube))]
[RequireComponent(typeof(Rigidbody))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _scaleDecrease = 2;
    [SerializeField] private int _spawnChanceDecrease = 2;
    [SerializeField] private int _spawnAmountMin = 2;
    [SerializeField] private int _spawnAmountMax = 6;
    [SerializeField] private ClickTrigger _clickTrigger;
    [SerializeField] private Cube _cube;

    public event Action<List<Rigidbody>> SpawnComplete;

    private void OnEnable()
    {
        _clickTrigger.Ñlicked += TrySpawn;
    }

    private void OnDisable()
    {
        _clickTrigger.Ñlicked -= TrySpawn;
    }

    private void DecreaseScale(float scaleDecrease)
    {
        transform.localScale /= scaleDecrease;
    }

    private void TrySpawn()
    {
        int spawnRoll = Utils.GenerateRandomNumber(0, 100);
        int _spawnChance = _cube.SpawnChance;

        if (_spawnChance >= spawnRoll)
        {
            DecreaseScale(_scaleDecrease);
            int newCubeSpawnChance = _spawnChance / _spawnChanceDecrease;
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

            SpawnComplete?.Invoke(spawnedCubesRigidbodies);
        }

        Destroy(_cube.GameObject());
    }
}