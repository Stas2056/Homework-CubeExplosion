using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _spawnChance;

    public int SpawnChance { get => _spawnChance; }

    public void Init(int spawnChance)
    {
        _spawnChance = spawnChance;
    }
}