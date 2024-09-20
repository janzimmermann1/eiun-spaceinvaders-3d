using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    public float _boundaryRadius = 1250f;
    private Transform _playerTransform;
    private Vector3 _boundaryCenter;
    
    void Start()
    {
        var _playerObject = GameObject.FindGameObjectWithTag("Player");
        _playerTransform = _playerObject.transform.parent.parent.transform;
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
            // Berechne die neue Position des Spielers direkt auf der Grenze
            Vector3 boundaryPoint = _boundaryCenter + direction.normalized * _boundaryRadius;

            // Setze die Position des Spielers auf den Rand der Grenze
            _playerTransform.position = boundaryPoint;
        }
    }
}
