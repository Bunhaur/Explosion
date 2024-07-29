using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private float _force = 500;
    private float _radius = 500;

    private void OnEnable()
    {
        _spawner.Created += Scatter;
    }

    private void OnDisable()
    {
        _spawner.Created -= Scatter;
    }

    private void Scatter(List<Rigidbody> cubes)
    {
        foreach (Rigidbody cube in cubes)
            cube.AddExplosionForce(_force, transform.position, _radius);
    }
}