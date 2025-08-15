using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _explosionForce=2500;

    public void Explode(Cube cube,List<Rigidbody> rigidbodies)
    {
        int explosionRadius = 10;

        foreach (Rigidbody spawnedCube in rigidbodies)
        {
            spawnedCube.AddExplosionForce(_explosionForce, cube.transform.localPosition, 
                                          explosionRadius);
        }
    }
}