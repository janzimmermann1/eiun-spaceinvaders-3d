using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour
{
    [SerializeField, Range(1, 10)] public float maxSpeed = 3f;
    [SerializeField, Range(100, 200)] public float neighborRadius = 200f;

    private GameObject _player;
    private SeparationBehaviour _separationBehaviour;
    private AlignmentBehaviour _alignmentBehaviour;
    private CohesionBehaviour _cohesionBehaviour;
    private ChaseBehaviour _chaseBehaviour;

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
        List<Transform> neighbors = FindNeighbors();
        Vector3 move = Vector3.zero;

        move += _chaseBehaviour.CalculateChase(_player);
        move += _cohesionBehaviour.CalculateCohesion(neighbors);
        move += _alignmentBehaviour.CalculateAlignment(neighbors);
        move += _separationBehaviour.CalculateSeparation(neighbors);

        MoveBoid(move);
    }

    private List<Transform> FindNeighbors()
    {
        List<Transform> neighbors = new();

        int enemyLayer = LayerMask.NameToLayer("Enemies");
        Collider[] colliders = Physics.OverlapSphere(transform.position, neighborRadius, 1 << enemyLayer);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy") && collider.transform != transform)
            {
                neighbors.Add(collider.transform);
            }
        }

        return neighbors;
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