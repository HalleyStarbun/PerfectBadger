using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePos;
    public float fireSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
