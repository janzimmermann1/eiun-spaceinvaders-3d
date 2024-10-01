using UnityEngine;

public class HomeUICameraMovement : MonoBehaviour
{
    public float speed = 0.3f;
    public float xRadius = 300.0f;
    public float yRadius = 50.0f;
    public float zRadius = 300.0f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float xMovement = Mathf.Sin(Time.time * speed) * xRadius;
        float yMovement = Mathf.Cos(Time.time * speed) * yRadius;
        float zMovement = Mathf.Sin(Time.time * speed * 0.5f) * zRadius; // Langsamere Bewegung

        transform.position = new Vector3(
            startPosition.x + xMovement, 
            startPosition.y + yMovement, 
            startPosition.z + zMovement);
    }
}