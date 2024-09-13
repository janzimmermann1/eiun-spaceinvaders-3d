using System.Collections.Generic;
using UnityEngine;

public class AlignmentBehaviour : MonoBehaviour
{
    [SerializeField, Range(1, 50)] public float alignmentStrength = 1f;

    public Vector3 CalculateAlignment(List<Transform> neighbors)
    {
        Vector3 alignmentForce = Vector3.zero;
        int count = 0;

        foreach (var neighbor in neighbors)
        {
            alignmentForce += neighbor.forward;  // Bewegungsrichtung des Nachbarn
            count++;
        }

        if (count > 0)
        {
            alignmentForce /= count;  // Durchschnittliche Richtung
            alignmentForce = alignmentForce.normalized;  // Richtung normalisieren
        }

        return alignmentForce * alignmentStrength;
    }
}