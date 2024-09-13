using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipExplode : MonoBehaviour
{
    public GameObject Explosion;
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ShipExplode: " + collision.gameObject.name);
        GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
        GameObject playerSpaceship = GameObject.FindGameObjectWithTag("Player");
        
        Destroy(playerSpaceship, 0.25f);
        Destroy(explosion, 4f);
    }
}
