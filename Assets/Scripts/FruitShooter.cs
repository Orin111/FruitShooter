using System.Collections;
using UnityEngine;

public class FruitShooter : MonoBehaviour
{
    public Game game; 
    public GameObject[] fruitPrefabs;
    public GameObject bombPrefab;
    public float minForce;
    public float maxForce;
    public float minTime = 1;
    public float maxTime = 3;
    public float minAngle = -60;
    public float maxAngle = 60;
    public bool gameMode = false;

    void Start()
    {
        // Ensure the Game script is attached to the game GameObject
        game = game.GetComponent<Game>();
        Debug.Log("1");
        StartCoroutine(ThrowLoop());
        Debug.Log("3");
    }

    IEnumerator ThrowLoop()
    {
        Debug.Log("2");
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            if (gameMode)
            {
                ThrowAFruit();
            }
        }
    }

    public void ThrowAFruit()
    {
        transform.parent.localEulerAngles = new Vector3(0, 0, Random.Range(minAngle, maxAngle));

        float randomValue = Random.value;
        GameObject selectedPrefab;

        if (randomValue <= 0.2f)
        {
            selectedPrefab = bombPrefab;
        }
        else
        {
            selectedPrefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
            // Increment the shots count through the Game script
            game.shotsCount++;
        }

        GameObject go = Instantiate(selectedPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Random.Range(minForce, maxForce));

        Vector3 torque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rb.AddTorque(torque * Random.Range(minForce, maxForce));
    }
}