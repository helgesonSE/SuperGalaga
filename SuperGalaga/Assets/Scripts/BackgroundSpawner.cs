using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public BackgroundObject[] BackgroundObjects;
    public float timer = 0f;
    private float spawnInterval = 0f; // Adjust as needed
    public int counter = 0;
    public int testCounter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Increment the timer by the time elapsed since the last frame
        timer += Time.deltaTime;

        // Check if it's time to spawn a new background object
        if (counter == 0 || (timer >= spawnInterval && counter < 3))
        {
            // Reset the timer
            timer = 0f;
            spawnInterval = Random.Range(8f, 20f);

            // Randomly select one of the background objects
            BackgroundObject objectToSpawn = BackgroundObjects[Random.Range(0, BackgroundObjects.Length)];

            // Spawn the selected object at the chosen start point
            BackgroundObject newObject = Instantiate(objectToSpawn, new Vector3(transform.position.x, Random.Range(-8f, 8f), 4f), Quaternion.identity);
            newObject.OnObjectDestroyed += HandleObjectDestroyed;
            counter++;
        }
    }

    private void HandleObjectDestroyed(BackgroundObject destroyedObject)
    {
        Destroy(destroyedObject.gameObject);
        counter--;
    }
}
