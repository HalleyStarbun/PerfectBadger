using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public int startingHealth = 100;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + startingHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + startingHealth.ToString();
    }
}
