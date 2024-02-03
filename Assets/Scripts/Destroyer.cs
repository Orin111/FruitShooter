using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public Game game; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            game.inc_survival();
        }
        
        // Destroy the collided GameObject
        Destroy(other.gameObject);
    }
}