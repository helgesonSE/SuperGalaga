using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    [SerializeField] private AudioClip shootSoundClip;
    private AudioSource audioSource;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        audioSource = GetComponent<AudioSource>();
=======

>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        // play sound
        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(shootSoundClip);
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}
