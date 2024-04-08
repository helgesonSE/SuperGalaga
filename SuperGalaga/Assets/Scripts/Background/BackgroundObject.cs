using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObject : MonoBehaviour
{
    public event Action<BackgroundObject> OnObjectDestroyed;
    public float scrollSpeed;
    public float rotation;
    public float scaleMod;
    public bool collided = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 currentScale = transform.localScale;
        scrollSpeed = UnityEngine.Random.Range(0.8f, 1f);
        scaleMod = UnityEngine.Random.Range(0.7f, 1.3f);
        transform.localScale = new Vector3(currentScale.x * scaleMod, currentScale.y * scaleMod, currentScale.z);
        transform.Rotate(0, 0, UnityEngine.Random.Range(0f, 360f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            collided = true;
            // Raise the event before destroying the object
            OnObjectDestroyed?.Invoke(this);
            //Destroy(this);
        }
    }
}
