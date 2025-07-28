using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private int _spawnChance;
    [SerializeField] private Spawner _spawner;

    public int SpawnChance { get => _spawnChance; }

    public void Init(int spawnChance)
    {
        _spawnChance = spawnChance;
    }
}