using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject emitter ;
    public void Explode () {
        print("BOOM!!!!");
        Instantiate(emitter,transform.position,transform.rotation);
        Die();
    }
    void Die(){
        Destroy(gameObject);
    }
}
