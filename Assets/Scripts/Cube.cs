using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _spawnChance;

    private Rigidbody _rigidbody;

    public int SpawnChance { get => _spawnChance; }
    public Rigidbody Rigidbody { get => _rigidbody; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(int spawnChance, float scaleDecrease)
    {
        _spawnChance = spawnChance;
        transform.localScale /= scaleDecrease;
    }
}