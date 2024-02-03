using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Game game;
    public CanvasManager canvasM;
    public Camera cam;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update () 
    {
        if(Input.GetMouseButtonDown(0)) Fire();
    }
    void Fire()
    {
        audioSource.Play();
        RaycastHit hit = new RaycastHit();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            Item item = hit.collider.gameObject.GetComponent<Item>();

            if (item != null)
            {
                item.Explode();

                // Check if the item has the "Bomb" tag
                if (hit.collider.CompareTag("Bomb"))
                {
                    canvasM.gameOver();
                    Debug.Log("Bomb was shoot");
                }
                else
                {
                    // Increment the survival count for other items
                    game.inc_survival();
                }

                Debug.Log(Time.time + " HIT!!!! " + hit.collider.gameObject.name);
            }
        }
    }

}