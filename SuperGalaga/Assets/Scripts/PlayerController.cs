using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float hInput;
    // [SerializeField] 
    // public float points = 50f;

    // public float points
    // {
    //     get { return _points; }
    //     set { _points = value; }
    // }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector2.left * hInput * moveSpeed * Time.deltaTime);
    }
}
