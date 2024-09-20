using System.Collections.Generic;
using UnityEngine;

public class AlignmentBehaviour : MonoBehaviour
{
    [SerializeField, Range(1, 50)] public float alignmentStrength = 5f;
    [SerializeField, Range(1, 200)] public float alignmentBoundary = 50f;

    public Vector3 CalculateAlignment(List<Transform> neighbors)
    {
        Vector3 alignmentForce = Vector3.zero;
        int count = 0;

        foreach (var neighbor in neighbors)
        {
            float distance = Vector3.Distance(transform.position, neighbor.position);

            if (distance > alignmentBoundary)
            {
                alignmentForce += neighbor.forward;
                count++;
            }
        }

        if (count > 0)
        {
            alignmentForce /= count; 
            alignmentForce = alignmentForce.normalized;
        }

        return alignmentForce * alignmentStrength;
    }
}