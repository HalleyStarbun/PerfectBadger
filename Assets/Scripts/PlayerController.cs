using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text healthText;
    private int hitPoints = 100;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + hitPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + hitPoints.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hitPoints -= 4;
        }
    }
}
