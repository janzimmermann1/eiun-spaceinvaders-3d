using System.Collections.Generic;
using UnityEngine;

public class CohesionBehaviour : MonoBehaviour
{
    [SerializeField, Range(1, 50)] public float cohesionStrength = 10f;
    [SerializeField, Range(1, 200)] public float cohesionBoundary = 70f;

    public Vector3 CalculateCohesion(List<Transform> neighbors)
    {
        Vector3 cohesionForce = Vector3.zero;
        int count = 0;

        foreach (var neighbor in neighbors)
        {
            float distance = Vector3.Distance(transform.position, neighbor.position);

            if (distance > cohesionBoundary)
            {
                Debug.Log("Cohesion from obj: " + this.gameObject.name + " to " + neighbor.gameObject.name);
                cohesionForce += neighbor.position;
                count++;
            }
        }

        if (count > 0)
        {
            cohesionForce /= count;
            cohesionForce = (cohesionForce - transform.position).normalized;
        }

        return cohesionForce * cohesionStrength;
    }
}