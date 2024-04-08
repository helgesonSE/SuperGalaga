using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    [SerializeField] private AudioClip shootSoundClip;
    [SerializeField] private AudioSource audioSource;

    public GameObject projectilePrefab;
    private bool triggerIsDown = false;
    private bool readyToShoot = true;
    private float bulletDelay = 0.3f; //Insert your desired delay...
    // Start is called before the first frame update
    void Start()
    {
        //shootSoundClip = GetComponent<AudioClip>();
        audioSource = GetComponent<AudioSource>(); //should this be the player ship?
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1") || triggerIsDown) && readyToShoot)
        {
            laserBullet();
            triggerIsDown = true;
        }

        if (Input.GetButtonUp("Fire1"))
            triggerIsDown = false;


    }
    void laserBullet()
    {

        audioSource.PlayOneShot(shootSoundClip); // Play sound
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        readyToShoot = false;
        StartCoroutine(WaitBetweenShots());

    }

    IEnumerator WaitBetweenShots()
    {
        yield return new WaitForSeconds(bulletDelay);

        readyToShoot = true;
    }
}
