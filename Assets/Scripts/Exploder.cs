using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _explosionForce=1500;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.SpawnComplete += Explode;
    }

    private void OnDisable()
    {
        _spawner.SpawnComplete -= Explode;
    }

    private void Explode(List<Rigidbody> rigidbodies)
    {       
        foreach (Rigidbody spawnedCube in rigidbodies)
        {
            spawnedCube.AddExplosionForce(_explosionForce, transform.localPosition, transform.localScale.x);
        }
    }
}