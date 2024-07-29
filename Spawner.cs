using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    public event Action<List<Rigidbody>> Created;

    private void OnEnable()
    {
        _cube.Splited += CreateCubes;
    }

    private void OnDisable()
    {
        _cube.Splited -= CreateCubes;
    }

    private void CreateCubes()
    {
        Cube newCube;
        Rigidbody rigidBody;

        List<Rigidbody> cubes = new List<Rigidbody>();

        for (int i = 0; i < GetRandomQuantityCubes(); i++)
        {
            newCube = Instantiate(_cube, transform.position, Quaternion.identity);
            rigidBody = newCube.GetComponent<Rigidbody>();
            cubes.Add(rigidBody);
        }

        Created?.Invoke(cubes);
    }

    private int GetRandomQuantityCubes()
    {
        int min = 2;
        int max = 6;

        return new System.Random().Next(min, max + 1);
    }
}