using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnimation : MonoBehaviour
{
    public float frequency = 6f; // Oscillation frequency (times per second)
    public float amplitude = 0.09f; // Oscillation amplitude (scale percentage)
    public float yAmplitudeMultiplier = 2f; // Multiplier for x-axis oscillation amplitude

    private Vector3 initialScale;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial scale of the object
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the time elapsed
        timeElapsed += Time.deltaTime;

        // Calculate the scale factor using the sine function
        float scaleFactor = Mathf.Sin(2f * Mathf.PI * frequency * timeElapsed) * amplitude;

        // Apply the oscillation effect to the scale, with a larger degree on the x-axis
        Vector3 scale = initialScale;
        scale.y += initialScale.y * scaleFactor * yAmplitudeMultiplier;


        transform.localScale = scale;
    }
}
