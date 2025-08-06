using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private RaycastTrigger _raycastTrigger;

    private void OnEnable()
    {
        _raycastTrigger.CubeClicked += TrySpawn;
    }

    private void OnDisable()
    {
        _raycastTrigger.CubeClicked -= TrySpawn;
    }

    private void TrySpawn(Cube cube)
    {
        List<Rigidbody> rigidbodies = _spawner.Spawn(cube);

        if (rigidbodies != null)
            _exploder.Explode(cube, rigidbodies);

        Destroy(cube.gameObject);
    }
}