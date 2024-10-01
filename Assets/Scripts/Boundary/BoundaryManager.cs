using System;
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    public float _boundaryRadius = 1250f;
    private Transform _playerTransform;
    private Vector3 _boundaryCenter;

    public event EventHandler BoundaryReached;

    protected virtual void OnBoundaryReached(bool hasReached)
    {
        BoundaryReached?.Invoke(this, new BoundaryReachedArgs { HasReached = hasReached });
    }

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

        // Wenn der Spieler nahe der Grenze ist
        if (distance > _boundaryRadius - 100)
        {
            OnBoundaryReached(hasReached: true);
        }
        else
        {
            OnBoundaryReached(hasReached: false);
        }

        // Zurücksetzen des Spielers, wenn er sich ausserhalb der Boundary befindet
        if (distance > _boundaryRadius)
        {
            Vector3 boundaryPoint = _boundaryCenter + direction.normalized * _boundaryRadius;
            _playerTransform.position = boundaryPoint;
        }
    }

    public class BoundaryReachedArgs : EventArgs
    {
        public bool HasReached { get; set; }
    }
}
