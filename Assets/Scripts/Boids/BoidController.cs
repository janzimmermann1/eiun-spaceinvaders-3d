using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour
{
    [SerializeField, Range(1, 10)] public float maxSpeed = 1f;
    [SerializeField, Range(40, 200)] public float neighborRadius = 50f;

    private GameObject _player;
    private SeparationBehaviour _separationBehaviour;
    private AlignmentBehaviour _alignmentBehaviour;
    private CohesionBehaviour _cohesionBehaviour;
    private ChaseBehaviour _chaseBehaviour;
    private List<Transform> _neighbors = new();

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _separationBehaviour = GetComponent<SeparationBehaviour>();
        _alignmentBehaviour = GetComponent<AlignmentBehaviour>();
        _cohesionBehaviour = GetComponent<CohesionBehaviour>();
        _chaseBehaviour = GetComponent<ChaseBehaviour>();
    }

    void Update()
    {
        FindNeighbors();
        Vector3 move = Vector3.zero;

        move += _chaseBehaviour.CalculateChase(_player);
        move += _cohesionBehaviour.CalculateCohesion(_neighbors);
        move += _alignmentBehaviour.CalculateAlignment(_neighbors);
        move += _separationBehaviour.CalculateSeparation(_neighbors);

        MoveBoid(move);
    }

    void FindNeighbors()
    {
        _neighbors.Clear();
        Collider[] colliders = Physics.OverlapSphere(transform.position, neighborRadius);
        foreach (var collider in colliders)
        {
            if (collider.transform != transform)
            {
                _neighbors.Add(collider.transform);
            }
        }
    }

    void MoveBoid(Vector3 move)
    {
        Vector3 newPosition = transform.position + move * (maxSpeed * Time.deltaTime);
        transform.position = newPosition;

        if (move != Vector3.zero)
        {
            transform.forward = move.normalized;
        }
    }
}