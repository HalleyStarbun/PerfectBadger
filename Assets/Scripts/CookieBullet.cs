using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieBullet : MonoBehaviour
{
    public float bulletSpeed;
    private float expirationTimer;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * bulletSpeed;
        expirationTimer += Time.deltaTime;
        if (expirationTimer > 2.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}