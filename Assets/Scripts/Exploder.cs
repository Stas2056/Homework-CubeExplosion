using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _explosionForce=1500;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.spawnComplete += Explode;
    }

    private void OnDisable()
    {
        _spawner.spawnComplete -= Explode;
    }

    private List<Rigidbody> GetSpawnedCubes()
    {
        Collider[] hits = Physics.OverlapBox(transform.localPosition, transform.localScale);

        List<Rigidbody> spawnedCubes = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                spawnedCubes.Add(hit.attachedRigidbody);
            }
        }

        return spawnedCubes;
    }

    private void Explode()
    {
        foreach (Rigidbody spawnedCube in GetSpawnedCubes())
        {
            spawnedCube.AddExplosionForce(_explosionForce, transform.localPosition, transform.localScale.x);
        }
    }
}