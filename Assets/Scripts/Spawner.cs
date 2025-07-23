using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private UnityEngine.Object _cube;
    [SerializeField] private float _scaleDecrease=2;
    [SerializeField] private int _spawnChance=100;
    [SerializeField] private ClickTrigger _clickTrigger;

    public event Action spawnComplete;

    private void OnEnable()
    {
        _clickTrigger.clicked += TrySpawn;
    }

    private void OnDisable()
    {
        _clickTrigger.clicked -= TrySpawn;
    }

    private void Clicked()
    {  
        Destroy(_cube);
    }

    private void DecreaseScale(float scaleDecrease)
    {
        transform.localScale /= scaleDecrease;
    }

    private void DecreaseNextSpawnChance()
    {
        int baseCoefficient = 2;
        _spawnChance /= baseCoefficient;
    }

    private void TrySpawn()
    {
        Debug.Log(".");
        int spawnRoll = Utils.GenerateRandomNumber(0, 100);
        Debug.Log("spawnRoll" + spawnRoll);
        Debug.Log("_spawnChance" + _spawnChance);

        if (_spawnChance >= spawnRoll)
        {
            DecreaseScale(_scaleDecrease);
            DecreaseNextSpawnChance();

            int spawnAmount = Utils.GenerateRandomNumber(2, 6);
            Debug.Log("spawnAmount" + spawnAmount);

            for (int i = 0; i < spawnAmount; i++)
            {
                Instantiate(transform.gameObject, RandomiseSpawnLocation(), Quaternion.identity);
            }

           spawnComplete?.Invoke();
        }

        Destroy(_cube);
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