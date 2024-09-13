using System.Collections.Generic;
using UnityEngine;

public class SeparationBehaviour : MonoBehaviour
{
    [SerializeField, Range(30, 200)] public float separationRadius = 20f;
    [SerializeField, Range(1, 50)] public float separationStrength = 20f;

    public Vector3 CalculateSeparation(List<Transform> neighbors)
    {
        Vector3 separationForce = Vector3.zero;
        int count = 0;

        foreach (var neighbor in neighbors)
        {
            float distance = Vector3.Distance(transform.position, neighbor.position);
            if (distance < separationRadius && distance > 0)
            {
                Vector3 direction = (transform.position - neighbor.position).normalized;
                separationForce += direction / distance;
                count++;
            }
        }

        if (count > 0)
        {
            separationForce /= count;
        }

        return separationForce * separationStrength;
    }
}