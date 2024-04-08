using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScroller
    : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float scrollSpeed = 0.001f;

    // Start is called before the first frame update

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
