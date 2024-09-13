using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
    [SerializeField, Range(1, 90)] public float chaseStrength = 1.5f;
    
    public Vector3 CalculateChase(GameObject player)
    {
        if (!player) return Vector3.zero;

        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        return directionToPlayer * chaseStrength;
    }
}