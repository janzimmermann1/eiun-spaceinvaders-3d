using UnityEngine;

public class SpaceshipExplode : MonoBehaviour
{
    public GameObject Explosion;
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ShipExplode: " + gameObject.name + " collided with " + collision.gameObject.name);
        GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
        GameObject spaceship = gameObject;
        if (!gameObject.CompareTag("Enemy"))
        {
            spaceship = GameObject.FindGameObjectWithTag("Player");
        }
        
        Destroy(spaceship, 0.1f);
        Destroy(explosion, 4f);
    }
}
