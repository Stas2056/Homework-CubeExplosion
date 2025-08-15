using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _spawnChance;

    public event Action<Cube> Clicked;

    private Rigidbody _rigidbody;

    public int SpawnChance => _spawnChance;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(int spawnChance, float scaleDecrease)
    {
        _spawnChance = spawnChance;
        transform.localScale /= scaleDecrease;
    }

    public void Disable()
    {
        Clicked?.Invoke(this);
    }
}