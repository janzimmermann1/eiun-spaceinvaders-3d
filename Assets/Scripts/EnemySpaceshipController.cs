using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceshipController : MonoBehaviour
{
    [SerializeField, Range(10, 300)] public float speed = 10f;
    [SerializeField, Range(10, 90)] public float rotationSpeed = 5f;
    private Transform playerTransform;

    void Start()
    {
        // Findet das Spielerobjekt anhand des Tags "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Kein Spieler mit dem Tag 'Player' gefunden!");
        }
    }

    void FixedUpdate()
    {
        if (playerTransform)
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Bewege das gegnerische Raumschiff in Richtung des Spielers
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }
}
