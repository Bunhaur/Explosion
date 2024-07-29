using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _baseChanseSeparation = 100;
    [SerializeField] private int _baseForce;
    [SerializeField] private int _baseRadius;

    private MeshRenderer _meshRenderer;

    public event Action Splited;
    public event Action<int, int> Explosion;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = UnityEngine.Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        if (IsSplit())
        {
            ChangeBaseStats();
            Splited?.Invoke();
        }
        else
        {
            Explosion?.Invoke(_baseForce, _baseRadius);
        }

        Destroy(gameObject);
    }

    private bool IsSplit()
    {
        int maxChance = 100;
        int chance = UnityEngine.Random.Range(1, maxChance);

        return chance < _baseChanseSeparation;
    }

    private void ChangeBaseStats()
    {
        int halfValue = 2;

        _baseChanseSeparation /= halfValue;
        transform.localScale /= halfValue;

        _baseForce *= halfValue;
        _baseRadius *= halfValue;
    }
}