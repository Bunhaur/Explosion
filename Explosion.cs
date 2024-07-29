using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private ParticleSystem _effect;

    private void OnEnable()
    {
        _cube.Explosion += BlowUp;
    }

    private void OnDisable()
    {
        _cube.Explosion -= BlowUp;
    }

    private void BlowUp(int force, int radius)
    {
        Instantiate(_effect, transform.position, Quaternion.identity);

        foreach (Rigidbody cube in GetExplosionObjects(radius))
            cube.AddExplosionForce(force, transform.position, radius);
    }

    private List<Rigidbody> GetExplosionObjects(int radius)
    {
        Collider[] hits;
        List<Rigidbody> cubes = new List<Rigidbody>();

        hits = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in hits)
            if(hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}