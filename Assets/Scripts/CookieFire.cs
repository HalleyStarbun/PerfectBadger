using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePos;
    public float fireSpeed;
    public float reloadTime;
    private float reloadTimer;

    // Update is called once per frame
    void Start()
    {
        reloadTimer = 0.0f;
    }

    void Update()
    {
        reloadTimer += Time.deltaTime;

        if (reloadTimer > reloadTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
                reloadTimer = 0.0f;
            }
        }
    }
}
