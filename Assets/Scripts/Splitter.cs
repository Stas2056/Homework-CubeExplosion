using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnMouseUpAsButton()
    {
        TrySpawn();
    }

    private void TrySpawn()
    {
        List<Rigidbody> rigidbodies = _spawner.Spawn();

        if (rigidbodies != null)
            _exploder.Explode(rigidbodies);

        Destroy(gameObject);
    }
}