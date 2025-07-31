using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _explosionForce=1500;
    [SerializeField] private Splitter _splitter;

    private void OnEnable()
    {
        _splitter.SpawnComplete += Explode;
    }

    private void OnDisable()
    {
        _splitter.SpawnComplete -= Explode;
    }

    private void Explode(List<Rigidbody> rigidbodies)
    {       
        foreach (Rigidbody spawnedCube in rigidbodies)
        {
            spawnedCube.AddExplosionForce(_explosionForce, transform.localPosition, transform.localScale.x);
        }
    }
}