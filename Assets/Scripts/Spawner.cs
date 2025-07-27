using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _scaleDecrease = 2;
    [SerializeField] private int _spawnChanceDecrease = 2;
    [SerializeField] private int _spawnAmountMin = 2;
    [SerializeField] private int _spawnAmountMax = 6;
    [SerializeField] private ClickTrigger _clickTrigger;
    [SerializeField] private Cube _cube;

    public event Action spawnComplete;

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

            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject newCubeObject = Instantiate(transform.gameObject, RandomiseSpawnLocation(), Quaternion.identity);
                Cube newCube = newCubeObject.GetComponent<Cube>();
                newCube.SetSpawnChance(newCubeSpawnChance);
            }

            spawnComplete?.Invoke();
        }

        Destroy(_cube._cube);
    }

    private Vector3 RandomiseSpawnLocation()
    {
        Vector3 randomSpawnLocation = new Vector3();

        randomSpawnLocation.x = transform.localPosition.x + Utils.GenerateRandomNumber(-10, 10) / 10;
        randomSpawnLocation.y = transform.localPosition.y + Utils.GenerateRandomNumber(-10, 10) / 10;
        randomSpawnLocation.z = transform.localPosition.z + Utils.GenerateRandomNumber(-10, 10) / 10;

        return randomSpawnLocation;
    }
}