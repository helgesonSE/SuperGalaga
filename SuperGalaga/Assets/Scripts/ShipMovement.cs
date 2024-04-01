using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left  * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
<<<<<<< Updated upstream:SuperGalaga/Assets/Scripts/ShipMovment.cs
            transform.position = new Vector3(transform.position.x-1, transform.position.y, transform.position.z);
=======
            transform.position = new Vector3 (transform.position.x -1, transform.position.y, transform.position.z);
>>>>>>> Stashed changes:SuperGalaga/Assets/Scripts/ShipMovement.cs
            moveSpeed *= -1;
        }
    }

}
