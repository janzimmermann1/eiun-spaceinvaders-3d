using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    private float _boundaryRadius;
    private Transform _playerTransform;
    private SphereCollider _boundaryCollider;
    private Vector3 _boundaryCenter;
    
    void Start()
    {

        var _playerObject = GameObject.FindGameObjectWithTag("Player");
        _playerTransform = _playerObject.transform.parent.transform;
        _boundaryCollider = GetComponent<SphereCollider>();
        _boundaryRadius = _boundaryCollider.radius;
        _boundaryCenter = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Distance between player and boundry
        Vector3 direction = _playerTransform.position - _boundaryCenter;
        float distance = direction.magnitude;

        // Wenn der Spieler außerhalb der Grenze ist
        if (distance > _boundaryRadius)
        {
            Debug.Log("Boundary overflown: " + distance);
            // Berechne die neue Position des Spielers direkt auf der Grenze
            Vector3 boundaryPoint = _boundaryCenter + direction.normalized * _boundaryRadius;

            // Setze die Position des Spielers auf den Rand der Grenze
            _playerTransform.position = boundaryPoint;
        }
    }
}
