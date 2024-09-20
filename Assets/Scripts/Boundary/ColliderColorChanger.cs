using UnityEngine;

public class ColliderColorChanger : MonoBehaviour
{
    private GameObject _player;
    public Material insideMaterial;

    private MeshRenderer _meshRenderer;
    private float _colliderRadius;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        // Hier wird der Radius des Sphere Colliders angenommen
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        _colliderRadius = sphereCollider.radius;
        
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        float distance = Vector3.Distance(_player.transform.position, transform.position);
        
        if (distance < _colliderRadius)
        {
            _meshRenderer.material = insideMaterial;
        }
        else
        {
            _meshRenderer.material = null;
        }
    }
}