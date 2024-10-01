using UnityEngine;

public class HomeUICameraMovement : MonoBehaviour
{
    // Definierbare Variablen für Geschwindigkeit und Bewegungsradius
    public float speed = 0.3f;
    public float xRadius = 300.0f;
    public float yRadius = 50.0f;
    public float zRadius = 300.0f;

    
    // Startposition der Kamera
    private Vector3 startPosition;

    void Start()
    {
        // Speichert die Startposition der Kamera
        startPosition = transform.position;
    }

    void Update()
    {
        // Berechnet die neue Position anhand von Sinus-Funktionen für sanfte Bewegung in X, Y und Z
        float xMovement = Mathf.Sin(Time.time * speed) * xRadius;
        float yMovement = Mathf.Cos(Time.time * speed) * yRadius;
        float zMovement = Mathf.Sin(Time.time * speed * 0.5f) * zRadius; // Z-Bewegung etwas langsamer für eine interessante Bewegung

        // Setzt die neue Position der Kamera
        transform.position = new Vector3(startPosition.x + xMovement, startPosition.y + yMovement, startPosition.z + zMovement);
    }
}