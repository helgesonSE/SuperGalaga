using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    [SerializeField] private AudioClip explosionSoundClip;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(explosionSoundClip);
    }




}
