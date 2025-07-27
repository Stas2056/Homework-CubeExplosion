using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] public GameObject _cube;
    [SerializeField] private int _spawnChance;
    [SerializeField] private Spawner _spawner;

    public int SpawnChance { get => _spawnChance;}
   
    public void SetSpawnChance(int SpawnChance)
    {
        _spawnChance =SpawnChance;
    }
}