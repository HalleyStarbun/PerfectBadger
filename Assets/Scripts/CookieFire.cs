using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePos;
    public float fireSpeed;
    public float reloadTime;
    public AudioClip[] fireSound;
    private float reloadTimer;
    private AudioSource audioSource;

    // Update is called once per frame
    void Start()
    {
        reloadTimer = 0.0f;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        reloadTimer += Time.deltaTime;

        if (reloadTimer > reloadTime)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
                audioSource.PlayOneShot(fireSound[0]);
                reloadTimer = 0.0f;
            }
        }
    }
}
