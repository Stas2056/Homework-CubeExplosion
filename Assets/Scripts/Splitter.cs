using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private ClickTrigger _clickTrigger;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Cube _cube;

    public event Action<List<Rigidbody>> SpawnComplete;

    private void OnEnable()
    {
        _clickTrigger.Clicked += TrySpawn;
    }

    private void OnDisable()
    {
        _clickTrigger.Clicked -= TrySpawn;
    }

    private void TrySpawn()
    {
        int spawnRoll = Utils.GenerateRandomNumber(0, 100);
        int spawnChance = _cube.SpawnChance;

        if (spawnChance >= spawnRoll)
        {
            SpawnComplete?.Invoke(_spawner.Spawn(spawnChance, _cube));
        }

        Destroy(_cube.GameObject());
    }
}