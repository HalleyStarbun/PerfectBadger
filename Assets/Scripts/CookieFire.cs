using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePos;
    public float fireSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
            //Debug.Log("Click!");
        }
    }
}
