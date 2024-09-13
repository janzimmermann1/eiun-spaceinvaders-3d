using System.Collections.Generic;
using UnityEngine;

public class CohesionBehaviour : MonoBehaviour
{
    [SerializeField, Range(1, 50)] public float cohesionStrength = 1f;

    public Vector3 CalculateCohesion(List<Transform> neighbors)
    {
        Vector3 cohesionForce = Vector3.zero;
        int count = 0;

        foreach (var neighbor in neighbors)
        {
            cohesionForce += neighbor.position;  // Position des Nachbarn
            count++;
        }

        if (count > 0)
        {
            cohesionForce /= count;  // Durchschnittliche Position
            cohesionForce = (cohesionForce - transform.position).normalized;  // Richtung zum Zentrum
        }

        return cohesionForce * cohesionStrength;
    }
}